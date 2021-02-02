using StudentPortal.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StudentPortal.ViewModels
{
    public class AdminHomeViewModel
    {
        public IEnumerable<AppUser> Students { get; set; }
        public IEnumerable<AppUser> Faculties { get; set; }
        public IEnumerable<Subject> Subjects { get; set; }
        public IEnumerable<Notice> Notices { get; set; }
    }
}
