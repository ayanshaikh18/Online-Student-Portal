using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StudentPortal.Models
{
    public class Result
    {
        public int Id { get; set; }
        public ExamType? Exam { get; set; }
        public int? Marks { get; set; }

        public int SubjectId { get; set; }
        public Subject Subject { get; set; }

        public string StudentId { get; set; }
        public AppUser Student { get; set; }
    }
}
