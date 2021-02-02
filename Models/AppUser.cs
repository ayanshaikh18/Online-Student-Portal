using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StudentPortal.Models
{
    public class AppUser:IdentityUser
    {
        //Common Fields
        public string Name { get; set; }
        public string Gender { get; set; }
        public Branch Branch { get; set; }
        public string Caste { get; set; }
        public string Address { get; set; }

        public DateTime BirthDate { get; set; }

        //Student's Fields
        public bool IsStudent { get; set; }
        public string HscBoard { get; set; }
        public double BoardResult { get; set; }

        //Faculty's Fields
        public bool IsFaculty { get; set; }
        public string Degree { get; set; }

        //
        public IList<FacultySubject> FacultySubjects { get; set; }
        public IList<Result> Results { get; set; }
        public IList<Submission> Submissions { get; set; }
        public IList<Assignment> Assignments { get; set; }

    }
}
