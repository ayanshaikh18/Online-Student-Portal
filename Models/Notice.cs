using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace StudentPortal.Models
{
    public class Notice
    {
        public int ID { get; set; }
        
        [Required]
        public string Description { get; set; }

        [Required]
        public string Title { get; set; }
        public string FilePath { get; set; }
        public string FileName { get; set; }
        public DateTime UploadDate { get; set; }
    }
}
