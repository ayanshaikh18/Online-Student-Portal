using StudentPortal.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace StudentPortal.ViewModels
{
    public class StudentRegisterViewModel
    {
        [Required]
        [EmailAddress]
        public string Email { get; set; }
        
        [Required]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        [Required]
        [DataType(DataType.Password)]
        [Display(Name ="Confirm Password")]
        [Compare("Password",
            ErrorMessage ="Passwords Don't match")]
        public string ConfirmPassword { get; set; }

        [Required]
        [Display(Name="Mobile Number : ")]
        public string PhoneNumber { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public string Gender { get; set; }
        public Branch Branch { get; set; }
        public string Caste { get; set; }
        
        [Display(Name ="Birth Date")]
        [DataType(DataType.Date)]
        [Required]
        public DateTime BirthDate { get; set; }

        [Display(Name ="HSC Board")]
        public string HscBoard { get; set; }

        public string Address { get; set; }

        [Display(Name="HSC Board Result")]
        public double BoardResult { get; set; }

    }
}
