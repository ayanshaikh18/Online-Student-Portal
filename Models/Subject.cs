using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StudentPortal.Models
{
    public class Subject
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public Branch? Branch { get; set; }

        public IList<FacultySubject> FacultySubjects { get; set; }
        public IList<Result> Results { get; set; }
        public IList<Assignment> Assignments { get; set; }

    }
}
