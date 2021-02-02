using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.Extensions.Hosting;
using StudentPortal.Models;
using StudentPortal.Models.Repositories;
using StudentPortal.ViewModels;

namespace StudentPortal.Controllers
{
    [Authorize(Roles ="Admin")]
    public class AdminController : Controller
    {
        private readonly IWebHostEnvironment hostingEnvironment;
        private readonly INoticeRepository noticeRepository;
        private readonly ISubjectRepository subjectRepository;
        private readonly UserManager<AppUser> userManager;
        public AdminController(IWebHostEnvironment _hostingEnvironment, 
            INoticeRepository _noticeRepository,
            UserManager<AppUser> _userManager,
            ISubjectRepository _subjectRepository)
        {
            hostingEnvironment = _hostingEnvironment;
            noticeRepository = _noticeRepository;
            userManager = _userManager;
            subjectRepository = _subjectRepository;
        }

        public IActionResult Index(int? page)
        {
            var users = userManager.Users;
            var model = new AdminHomeViewModel();
            model.Notices = noticeRepository.GetAllNotices();
            model.Subjects= subjectRepository.GetAllSubjects();
            model.Students = users.Where(u => u.IsStudent == true).ToList();
            model.Faculties = users.Where(u => u.IsFaculty == true).ToList();
            if (page != null)
                return View("Index1", model);
            return View(model);
        }

        [HttpGet]
        public IActionResult NewNotice()
        {
            return View();
        }

        [HttpPost]
        public IActionResult NewNotice(NoticeViewModel model)
        {
            if (ModelState.IsValid)
            {
                string uniqueFileName = null;
                if (model.File != null)
                {
                    string uploadPath = Path.Combine(hostingEnvironment.WebRootPath,"files");
                    uniqueFileName = Guid.NewGuid().ToString() + "_" + model.File.FileName;
                    string filePath = Path.Combine(uploadPath, uniqueFileName);
                    model.File.CopyTo(new FileStream(filePath,FileMode.Create));
                }
                Notice notice = new Notice
                {
                    Title = model.Title,
                    Description = model.Description,
                    UploadDate = System.DateTime.Now,
                    FilePath = uniqueFileName,
                    FileName=model.FileName
                };
                noticeRepository.Add(notice);
                return RedirectToAction("notice");
            }
            return View(model);
        }

        public IActionResult Notice()
        {
            return View(noticeRepository.GetAllNotices().OrderByDescending(n => n.UploadDate));
        }

        [HttpGet]
        public IActionResult EditNotice(int id)
        {
            var notice = noticeRepository.GetNotice(id);
            var NoticeViewModel = new NoticeViewModel()
            {
                Description = notice.Description,
                FileName = notice.FileName,
                Title = notice.Title
            };
            ViewBag.Id = notice.ID;
            ViewBag.FilePath = notice.FilePath;
            return View(NoticeViewModel);
        }

        [HttpPost]
        public IActionResult EditNotice(NoticeViewModel model,int id)
        {
            if (ModelState.IsValid)
            {
                var notice = noticeRepository.GetNotice(id);
                string uniqueFileName = notice.FilePath;
                if (model.File != null)
                {
                    if(uniqueFileName != null)
                    {
                        string existingFilePath = Path.Combine(hostingEnvironment.WebRootPath, "files", uniqueFileName);
                        System.IO.File.Delete(existingFilePath);
                    }
                    string uploadPath = Path.Combine(hostingEnvironment.WebRootPath, "files");
                    uniqueFileName = Guid.NewGuid().ToString() + "_" + model.File.FileName;
                    string filePath = Path.Combine(uploadPath, uniqueFileName);
                    model.File.CopyTo(new FileStream(filePath, FileMode.Create));
                }
                notice.Description = model.Description;
                notice.UploadDate = System.DateTime.Now;
                notice.FilePath = uniqueFileName;
                notice.FileName = model.FileName;
                noticeRepository.Update(notice);
                return RedirectToAction("notice");
            }
            return View(model);
        }

        [HttpPost]
        public IActionResult DeleteNotice(int id)
        {
            var notice = noticeRepository.GetNotice(id);
            if (notice.FilePath != null)
            {
                string existingFilePath = Path.Combine(hostingEnvironment.WebRootPath, "files", notice.FilePath);
                System.IO.File.Delete(existingFilePath);
            }
            noticeRepository.Delete(id);
            return RedirectToAction("notice");
        }

        [HttpGet]
        public IActionResult NewSubject()
        {
            var newSubjectViewModel = new NewSubjectViewModel();
            newSubjectViewModel.AllFaculties = userManager.Users.Where(u => u.IsFaculty == true)
                                    .Select(a => new SelectListItem()
                                    {
                                        Value = a.Id,
                                        Text = a.Name,
                                    })
                                    .ToList();
            return View(newSubjectViewModel);
        }

        [HttpPost]
        public IActionResult NewSubject(NewSubjectViewModel model)
        {
            if (ModelState.IsValid)
            {
                Subject subject = new Subject();
                subject.Name = model.Name;
                subject.Branch = model.Branch;
                subject.FacultySubjects = new List<FacultySubject>();
                if(model.Faculties!=null)
                    foreach (var fac in model.Faculties)
                        subject.FacultySubjects.Add(new FacultySubject { FacultyId = fac ,Requested=false});
                subjectRepository.Add(subject, model.Faculties);
                return RedirectToAction("AllSubjects","admin");
            }
            return View(model);
        }
        
        public JsonResult getFaculties(int branch)
        {
            IEnumerable<SelectListItem> faculties 
                = userManager.Users
                             .Where(f => f.IsFaculty == true && f.Branch == (Branch) branch)
                             .Select(a => new SelectListItem()
                             {
                                Value = a.Id,
                                Text = a.Name
                             })
                             .ToList();
            return Json(faculties);
        }

        public IActionResult AllSubjects()
        {
            AdminSubjectListViewModel model = new AdminSubjectListViewModel();
            model.Subjects = subjectRepository.GetAllSubjects();
            model.Requests = subjectRepository.GetAllSubjectRequests();
            return View(model);
        }
        
        [HttpPost]
        public IActionResult acceptRequest(int sid,string fid)
        {
            subjectRepository.acceptRequest(sid, fid);
            return RedirectToAction("allSubjects","admin");
        }

        [HttpPost]
        public IActionResult rejectRequest(int sid, string fid)
        {
            subjectRepository.rejectRequest(sid, fid);
            return RedirectToAction("allSubjects", "admin");
        }

        [HttpGet]
        public IActionResult EditSubject(int id)
        {
            var sub = subjectRepository.GetSubject(id);
            NewSubjectViewModel model = new NewSubjectViewModel
            {
                Name = sub.Name,
                Branch = sub.Branch,
                Faculties = sub.FacultySubjects.Where(fs=>fs.Requested==false).Select(s => s.FacultyId).ToList(),
                AllFaculties = userManager.Users.Where(u => u.IsFaculty == true && u.Branch==sub.Branch)
                                    .Select(a => new SelectListItem()
                                    {
                                        Value = a.Id,
                                        Text = a.Name,
                                    })
                                    .ToList()
            };
            ViewBag.Id = id;
            return View(model);
        }
        [HttpPost]
        public IActionResult EditSubject(NewSubjectViewModel model,int id)
        {
            if (ModelState.IsValid)
            {
                var sub = subjectRepository.GetSubject(id);
                sub.Name = model.Name;
                sub.Branch = model.Branch;
                sub.FacultySubjects.Clear();
                foreach (var fac in model.Faculties)
                    sub.FacultySubjects.Add(new FacultySubject { FacultyId = fac ,Requested=false});
                subjectRepository.Update(sub);
                return RedirectToAction("allsubjects", "admin");
            }
            return this.EditSubject(id);
        }

        [HttpPost]
        public IActionResult DeleteSubject(int id)
        {
            subjectRepository.Delete(id);
            return RedirectToAction("allsubjects", "admin");
        }

        public async Task<IActionResult> UserDetails(string id)
        {
            var user = await userManager.FindByIdAsync(id);
            return View(user);
        }
    }
}