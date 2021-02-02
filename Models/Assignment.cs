using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace StudentPortal.Models
{
    public class Assignment
    {
        public int Id { get; set; }
        [Required]
        public string Title { get; set; }
        [Required]
        public string Description { get; set; }

        [Required]
        [Display(Name ="Subject")]
        public int SubjectId { get; set; }
        public Subject Subject { get; set; }
        
        
        public string FacultyId { get; set; }
        public AppUser Faculty { get; set; }

        public IList<Submission> Submissions { get; set; }
    }
}
