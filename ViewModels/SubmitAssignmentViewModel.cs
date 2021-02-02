using Microsoft.AspNetCore.Http;
using StudentPortal.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StudentPortal.ViewModels
{
    public class SubmitAssignmentViewModel:Submission
    {
        public IFormFile File { get; set; }
    }
}
