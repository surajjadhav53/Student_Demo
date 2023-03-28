using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Student_Demo.Models
{
    public class Login
    {
        [Required]
        [Display(Name ="Enter Username :")]
        public string UserName { get; set; }

        [Required]
        [DataType(DataType.Password)]
        [Display(Name = "Enter Password :")]
        public string Password { get; set; }
    }
}