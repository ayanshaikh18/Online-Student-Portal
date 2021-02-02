using StudentPortal.Models.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StudentPortal.Models.RepoImplementation
{
    public class AssignmentRepository : IAssignmentRepository
    {
        private readonly AppDbContext context;
        public AssignmentRepository(AppDbContext _context)
        {
            context = _context;
        }
        public void Add(Assignment assignment)
        {
            assignment.Subject = null;
            assignment.Faculty = null;
            context.Assignments.Add(assignment);
            context.SaveChanges();
        }

        public void AddSubmission(Submission submission)
        {
            context.Submissions.Add(submission);
            context.SaveChanges();
        }

        public IEnumerable<Assignment> GetAllAssignments()
        {
            return context.Assignments;
        }

        public Assignment GetAssignment(int id)
        {
            return context.Assignments.Find(id);
        }

        public Submission GetSubmissionByAssignment(int id,string sid)
        {
            return context.Submissions.Where(a => a.AssignmentId == id && a.StudentId == sid).FirstOrDefault();
        }

        public IEnumerable<Submission> GetSubmissionsByAssignment(int id)
        {
            return context.Submissions.Where(s => s.AssignmentId == id);
        }
    }
}
