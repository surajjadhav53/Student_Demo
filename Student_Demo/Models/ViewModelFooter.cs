using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Student_Demo.Models
{
    public class ViewModelFooter
    {
        public int Id { get; set; }
        [Required]
        public string Displaytext { get; set; }
        [Required]
        public string LinkUrl { get; set; }
    }
}