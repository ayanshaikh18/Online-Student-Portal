using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace StudentPortal.ViewModels
{
    public class NoticeViewModel
    {
        [Required]
        public string Title { get; set; }
        [Required]
        public string Description { get; set; }

        [Display(Name ="Files's Display Name")]
        public string FileName { get; set; }
        public IFormFile? File { get; set; }
    }
}
