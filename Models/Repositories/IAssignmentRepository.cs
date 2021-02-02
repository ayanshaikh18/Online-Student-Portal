using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StudentPortal.Models.Repositories
{
    public interface IAssignmentRepository
    {
        void Add(Assignment assignment);
        IEnumerable<Assignment> GetAllAssignments();
        Assignment GetAssignment(int id);
        Submission GetSubmissionByAssignment(int id,string sid);
        void AddSubmission(Submission submission);
        IEnumerable<Submission> GetSubmissionsByAssignment(int id);
    }
}
