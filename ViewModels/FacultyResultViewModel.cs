using StudentPortal.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace StudentPortal.ViewModels
{
    public class FacultyResultViewModel
    {
        public ExamType Exam { get; set; }

        [Display(Name ="Subject")]
        [Required]
        public int SubjectId { get; set; }
        public IEnumerable<FacultySubject> AllSubjects { get; set; }
    }
}
