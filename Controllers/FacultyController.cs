using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using StudentPortal.Models;
using StudentPortal.Models.Repositories;
using StudentPortal.ViewModels;

namespace StudentPortal.Controllers
{
    [Authorize(Roles = "Faculty")]
    public class FacultyController : Controller
    {
        private readonly UserManager<AppUser> userManager;
        private readonly ISubjectRepository subjectRepository;
        private readonly IResultRepository resultRepository;
        private readonly IAssignmentRepository assignmentRepository;
        public FacultyController(UserManager<AppUser> _userManager,
                                 ISubjectRepository _subjectRepository,
                                 IResultRepository _resultRepository,
                                 IAssignmentRepository _assignmentRepository)
        {
            userManager = _userManager;
            subjectRepository = _subjectRepository;
            resultRepository = _resultRepository;
            assignmentRepository = _assignmentRepository;
        }
        public async Task<IActionResult> Index()
        {
            var user = await userManager.GetUserAsync(HttpContext.User);
            return View(user);
        }

        [HttpGet]
        public async Task<IActionResult> EditDetails()
        {
            var user = await userManager.GetUserAsync(HttpContext.User);
            return View(user);
        }

        [HttpPost]
        public async Task<IActionResult> EditDetails(AppUser model)
        {
            if(ModelState.IsValid)
            {
                var user = await userManager.GetUserAsync(HttpContext.User);
                user.UserName = model.Email;
                user.Email = model.Email;
                user.Name = model.Name;
                user.PhoneNumber = model.PhoneNumber;
                user.BirthDate = model.BirthDate;
                user.Address = model.Address;
                user.Gender = model.Gender;
                user.Caste = model.Caste;
                user.Degree = model.Degree;
                user.IsFaculty = true;
                var result = await userManager.UpdateAsync(user);
                if (result.Succeeded)
                {
                    return RedirectToAction("index", "faculty");
                }
                foreach (var error in result.Errors)
                    ModelState.AddModelError("", error.Description);
            }
            return View(model);
        }

        [HttpGet]
        public async Task<IActionResult> subjects()
        {
            var facultySubjectListViewModel = new FacultySubjectListViewModel { 
                AccessibleSubjects = new List<Subject>(),
                NotAccessibleSubjects = new List<Subject>(),
                requestedSubjects = new List<Subject>()
            };
            var user = await userManager.GetUserAsync(HttpContext.User);
            var allSubjects = subjectRepository.GetAllSubjects().Where(s => s.Branch == user.Branch);
            foreach(var subject in allSubjects)
            {
                bool found = false, requested = false;
                foreach(var fs in subject.FacultySubjects)
                {
                    if (fs.FacultyId == user.Id)
                    {
                        found = true;
                        requested = fs.Requested;
                        break;
                    }
                }
                if (found)
                {
                    if (requested)
                        facultySubjectListViewModel.requestedSubjects.Add(subject);
                    else
                        facultySubjectListViewModel.AccessibleSubjects.Add(subject);
                }
                else
                    facultySubjectListViewModel.NotAccessibleSubjects.Add(subject);
            }
            return View(facultySubjectListViewModel);
        }

        [HttpPost]
        public async Task<IActionResult> subjects(int id,string cancel)
        {
            var user = await userManager.GetUserAsync(HttpContext.User);
            if (cancel=="true")
                subjectRepository.rejectRequest(id, user.Id);
            else
                subjectRepository.requestSubjectAccess(id, user.Id);
            return (await this.subjects());

        }

        [HttpGet]
        public async Task<IActionResult> Results()
        {
            var user = await userManager.GetUserAsync(HttpContext.User);
            var model = new FacultyResultViewModel();
            model.AllSubjects = subjectRepository.GetFacultySubjectsOfFaculty(user.Id);
            var students = userManager.Users.Where(u => u.IsStudent == true && u.Branch == user.Branch);
            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> Results(FacultyResultViewModel model)
        {
            if (ModelState.IsValid)
            {
                var subId = model.SubjectId;
                var exam = model.Exam;
                var subject = subjectRepository.GetSubject(subId);
                ViewBag.Subject = subject;
                ViewBag.Exam = exam;
                var results = resultRepository.GetResultsBySubject(subId, exam).ToList();
                var students = userManager.Users.Where(u => u.IsStudent == true && u.Branch == subject.Branch).ToList();
                if (results.Count() == 0)
                {
                    IList<Result> results1 = new List<Result>();
                    foreach(var student in students)
                    {
                        results1.Add(new Result
                        {
                            Student = student,
                            StudentId = student.Id,
                            Subject = subject,
                            SubjectId =subId,
                            Exam = exam,
                            Marks = null
                        });
                    }
                    
                    return View("CreateResult", results1);
                }
                foreach (var res in results)
                {
                    res.Student = students.Where(s => s.Id == res.StudentId).First();
                }
                foreach(var student in students)
                {
                    int cnt = results.Where(r => r.StudentId == student.Id).Count();
                    if (cnt == 0)
                    {
                        results.Add(new Result
                        {
                            Student = student,
                            StudentId = student.Id,
                            Subject = subject,
                            SubjectId = subId,
                            Exam = exam,
                            Marks = null
                        });
                    }
                }
                return View("CreateResult", results);
            }
            return await this.Results();
        }

        [HttpPost]
        public IActionResult CreateResult(IList<Result> model)
        {
            resultRepository.Add(model);
            return RedirectToAction("results", "faculty");
        }

        [HttpGet]
        public async Task<IActionResult> NewAssignment()
        {
            var user = await userManager.GetUserAsync(HttpContext.User);
            NewAssignmentViewModel newAssignmentViewModel = new NewAssignmentViewModel();
            newAssignmentViewModel.AllSubjects = subjectRepository.GetFacultySubjectsOfFaculty(user.Id);
            return View(newAssignmentViewModel);
        }

        [HttpPost]
        public async Task<IActionResult> NewAssignment(NewAssignmentViewModel model)
        {
            if (ModelState.IsValid)
            {
                var user = await userManager.GetUserAsync(HttpContext.User);
                Assignment assignment = new Assignment
                {
                    Title=model.Title,
                    Description = model.Description,
                    SubjectId = model.SubjectId,
                    FacultyId = user.Id
                };
                assignmentRepository.Add(assignment);
                return RedirectToAction("assignments", "faculty");
            }
            return await this.NewAssignment();
        }

        public async Task<IActionResult> Assignments()
        {
            var user = await userManager.GetUserAsync(HttpContext.User);
            var assignments= assignmentRepository.GetAllAssignments().Where(a => a.FacultyId == user.Id).ToList();
            var subjects = subjectRepository.GetAllSubjects().Where(s => s.Branch == user.Branch).ToList();
            foreach(var assignment in assignments)
            {
                assignment.Subject = subjects.Where(s => s.Id == assignment.SubjectId).First();
            }
            return View(assignments);
        }

        public IActionResult ViewSubmissions(int id)
        {
            var assignment = assignmentRepository.GetAssignment(id);
            var submissions=assignmentRepository.GetSubmissionsByAssignment(id);
            var subject = subjectRepository.GetSubject(assignment.SubjectId);
            ViewBag.SubjectName = subject.Name;
            ViewBag.Title = assignment.Title;
            var users = userManager.Users.ToList();
            foreach (var submission in submissions)
                submission.Student = users.Where(u => u.Id == submission.StudentId).FirstOrDefault();
            return View(submissions.ToList());
        }

    }

}
