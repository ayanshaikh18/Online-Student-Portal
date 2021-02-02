using StudentPortal.Models.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StudentPortal.Models.RepoImplementation
{
    public class ResultRepository : IResultRepository
    {
        private readonly AppDbContext context;
        public ResultRepository(AppDbContext context)
        {
            this.context = context;
        }
        public void Add(IEnumerable<Result> results)
        {
            foreach(var res in results)
            {
                if (res.Id == 0)
                {
                    context.Results.Add(res);
                    continue;
                }
                var resUpdated = context.Results.Attach(res);
                resUpdated.State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            }
            context.SaveChanges();
        }

        public IEnumerable<Result> GetResultsByStudent(string SId)
        {
            return context.Results.Where(res => res.StudentId == SId);
        }

        public IEnumerable<Result> GetResultsBySubject(int SubjectId, ExamType exam)
        {
            return context.Results.Where(r => r.SubjectId == SubjectId && r.Exam == exam);
        }
    }
}
