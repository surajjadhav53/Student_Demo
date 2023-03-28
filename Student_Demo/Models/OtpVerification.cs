using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Student_Demo.Models
{
    public class OtpVerification
    {
        [Required]
        [Display(Name ="Enter Otp :")]
       
        public int OTP { get; set; }
    }
}