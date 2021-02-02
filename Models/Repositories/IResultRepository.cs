using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StudentPortal.Models.Repositories
{
    public interface IResultRepository
    {
        void Add(IEnumerable<Result> results);
        IEnumerable<Result> GetResultsBySubject(int SubjectId, ExamType exam);
        IEnumerable<Result> GetResultsByStudent(string SId);
    }
}
