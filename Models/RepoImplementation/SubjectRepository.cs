using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using StudentPortal.Models.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StudentPortal.Models.RepoImplementation
{
    public class SubjectRepository:ISubjectRepository
    {
        private readonly AppDbContext context;
        private readonly UserManager<AppUser> userManager;
        public SubjectRepository(AppDbContext _context,UserManager<AppUser> _userManager)
        {
            context = _context;
            userManager = _userManager;
        }
        public Subject Add(Subject Subject,IEnumerable<string> facultiesId)
        {
            context.Subjects.Add(Subject);
            context.SaveChanges();
            return Subject;
        }

        public Subject Delete(int id)
        {
            var Subject = context.Subjects.Find(id);
            if (Subject != null)
            {
                context.Subjects.Remove(Subject);
                context.SaveChanges();
            }
            return Subject;
        }

        public IEnumerable<Subject> GetAllSubjects()
        {
            return context.Subjects.Include(subject=>subject.FacultySubjects);
        }

        public Subject GetSubject(int id)
        {
            return context.Subjects.Include(sub=>sub.FacultySubjects).Where(s=>s.Id==id).First();
        }

        public Subject Update(Subject SubjectModified)
        {
            var Subject = context.Subjects.Attach(SubjectModified);
            Subject.State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            context.SaveChanges();
            return SubjectModified;
        }

        public void requestSubjectAccess(int SId, string FId)
        {
            FacultySubject facultySubject = new FacultySubject
            {
                SubjectId = SId,
                FacultyId = FId,
                Requested = true
            };
            context.FacultySubjects.Add(facultySubject);
            context.SaveChanges();
        }

        public IEnumerable<FacultySubject> GetAllSubjectRequests()
        {
            var requests = context.FacultySubjects
                .Include(fs => fs.Faculty)
                .Include(fs => fs.Subject)
                .Where(fs => fs.Requested == true);
            return requests;
        }

        public void acceptRequest(int sid, string fid)
        {
            var req=context.FacultySubjects.Find(fid,sid);
            req.Requested = false;
            context.Attach(req);
            context.SaveChanges();
        }

        public void rejectRequest(int sid, string fid)
        {
            var req = context.FacultySubjects.Find(fid, sid);
            context.FacultySubjects.Remove(req);
            context.SaveChanges();
        }

        public IEnumerable<FacultySubject> GetFacultySubjectsOfFaculty(string id)
        {
            return context.FacultySubjects
                          .Include(fs=>fs.Subject)
                          .Include(fs=>fs.Faculty).
                          Where(fs => fs.FacultyId == id && fs.Requested == false);
        }
    }
}
