using Microsoft.AspNetCore.Mvc.Rendering;
using StudentPortal.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace StudentPortal.ViewModels
{
    public class NewSubjectViewModel
    {
        [Required]
        public string Name { get; set; }

        public List<SelectListItem> AllFaculties { get; set; }
        public IEnumerable<string> Faculties { get; set; }
        
        [Required(ErrorMessage ="Please Select Branch")]
        public Branch? Branch { get; set; }
    }
}
