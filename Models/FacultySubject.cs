using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StudentPortal.Models
{
    public class FacultySubject
    {
        public string FacultyId { get; set; }
        public AppUser Faculty { get; set; }
        public bool Requested { get; set; }

        public int SubjectId { get; set; }
        public Subject Subject { get; set; }
    }
}
