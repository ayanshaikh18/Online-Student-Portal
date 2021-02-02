using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using StudentPortal.Models;
using StudentPortal.Models.Repositories;
using StudentPortal.ViewModels;

namespace StudentPortal.Controllers.Student
{
    [Authorize(Roles ="Student")]
    public class StudentController : Controller
    {
        private readonly UserManager<AppUser> userManager;
        private readonly INoticeRepository noticeRepository;
        private readonly IResultRepository resultRepository;
        private readonly ISubjectRepository subjectRepository;
        private readonly IAssignmentRepository assignmentRepository;
        private readonly IWebHostEnvironment hostingEnvironment;
        public StudentController(UserManager<AppUser> _userManager,
                                 INoticeRepository _noticeRepository,
                                 IResultRepository _resultRepository,
                                 ISubjectRepository _subjectRepository,
                                 IAssignmentRepository _assignmentRepository,
                                 IWebHostEnvironment _webHostEnvironment)
        {
            userManager = _userManager;
            noticeRepository = _noticeRepository;
            resultRepository = _resultRepository;
            subjectRepository = _subjectRepository;
            assignmentRepository = _assignmentRepository;
            hostingEnvironment = _webHostEnvironment;
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
            if (ModelState.IsValid)
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
                user.HscBoard = model.HscBoard;
                user.BoardResult = model.BoardResult;
                var result = await userManager.UpdateAsync(user);
                if (result.Succeeded)
                {
                    return RedirectToAction("index");
                }
                foreach (var error in result.Errors)
                    ModelState.AddModelError("", error.Description);
            }
            return View(model);
        }

        public IActionResult notice()
        {
            return View(noticeRepository.GetAllNotices().OrderByDescending(n=>n.UploadDate));
        }

        [HttpGet]
        public IActionResult Result()
        {
            return View();
        }

        public async Task<IActionResult> Result1(ExamType Exam)
        {
            var user = await userManager.GetUserAsync(HttpContext.User);
            var results = resultRepository.GetResultsByStudent(user.Id).Where(r=>r.Exam==Exam);
            var subjects = subjectRepository.GetAllSubjects().ToList();
            foreach (var res in results)
                res.Subject = subjects.Where(s => s.Id == res.SubjectId).First();
            ViewBag.Name = user.Name;
            ViewBag.Exam = Exam;
            return View("DisplayResult",results);
        }

        public async Task<IActionResult> Assignments()
        {
            var user = await userManager.GetUserAsync(HttpContext.User);
            var subjects = subjectRepository.GetAllSubjects().ToList();
            var users = userManager.Users.ToList();
            IList<Assignment> assignments = new List<Assignment>();
            var allAssignments = assignmentRepository.GetAllAssignments().ToList();
            foreach(var assignment in allAssignments)
            {
                assignment.Subject = subjects.Where(s => s.Id == assignment.SubjectId).First();
                if (assignment.Subject.Branch == user.Branch)
                {
                    assignment.Faculty = users.Where(u => u.Id == assignment.FacultyId).First();
                    assignments.Add(assignment);
                }
            }
            return View(assignments);
        }

        [HttpGet]
        public async Task<IActionResult> SubmitAssignment(int Id)
        {
            var user = await userManager.GetUserAsync(HttpContext.User);
            var submission = assignmentRepository.GetSubmissionByAssignment(Id,user.Id);
            if (submission == null)
            {
                ViewBag.isSubmitted = false;
                SubmitAssignmentViewModel model = new SubmitAssignmentViewModel();
                model.AssignmentId = Id;
                model.Assignment = assignmentRepository.GetAssignment(Id);
                model.Assignment.Subject = subjectRepository.GetSubject(model.Assignment.SubjectId);
                return View(model);
            }
            else
            {
                ViewBag.isSubmitted = true;
                SubmitAssignmentViewModel model = new SubmitAssignmentViewModel();
                model.AssignmentId = Id;
                model.Assignment = assignmentRepository.GetAssignment(Id);
                model.Assignment.Subject = subjectRepository.GetSubject(model.Assignment.SubjectId);
                model.FilePath = submission.FilePath;
                return View(model);
            }
        }

        [HttpPost]
        public async Task<IActionResult> SubmitAssignment(SubmitAssignmentViewModel model)
        {
            if (ModelState.IsValid)
            {
                var user = await userManager.GetUserAsync(HttpContext.User);
                string uniqueFileName = null;
                string uploadPath = Path.Combine(hostingEnvironment.WebRootPath,"files");
                uniqueFileName = Guid.NewGuid().ToString() + "_" + model.File.FileName;
                string path = Path.Combine(uploadPath, uniqueFileName);
                model.File.CopyTo(new FileStream(path,FileMode.Create));

                Submission submission = new Submission
                {
                    AssignmentId = model.AssignmentId,
                    StudentId = user.Id,
                    FilePath = uniqueFileName,                    
                };
                assignmentRepository.AddSubmission(submission);
                return RedirectToAction("assignments","student");
            }
            return View(model);
        }
    }
}
