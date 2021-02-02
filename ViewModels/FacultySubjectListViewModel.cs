using StudentPortal.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StudentPortal.ViewModels
{
    public class FacultySubjectListViewModel
    {
        public List<Subject> AccessibleSubjects { get; set; }
        public List<Subject> NotAccessibleSubjects { get; set; }
        public List<Subject> requestedSubjects { get; set; }
    }
}
