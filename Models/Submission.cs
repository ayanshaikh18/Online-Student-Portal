using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StudentPortal.Models
{
    public class Submission
    {
        public int Id { get; set; }
        public string FilePath { get; set; }

        public int AssignmentId { get; set; }
        public Assignment Assignment { get; set; }

        public string StudentId { get; set; }
        public AppUser Student { get; set; }
    }
}
