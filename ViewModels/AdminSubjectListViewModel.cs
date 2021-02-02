using StudentPortal.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StudentPortal.ViewModels
{
    public class AdminSubjectListViewModel
    {
        public IEnumerable<FacultySubject> Requests { get; set; }
        public IEnumerable<Subject> Subjects { get; set; }
    }
}
