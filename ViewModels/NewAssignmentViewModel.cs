using StudentPortal.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StudentPortal.ViewModels
{
    public class NewAssignmentViewModel:Assignment
    {
        public IEnumerable<FacultySubject> AllSubjects { get; set; }
    }
}
