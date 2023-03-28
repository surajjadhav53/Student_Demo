using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Student_Demo.Models
{
    public class Student
    {
        public int Id { get; set; }
        [Display(Name = "Employee Name")]
        [Required(ErrorMessage = "Name is mandatory")]
        public string Name { get; set; }
        [DataType(DataType.MultilineText)]
        [MaxLength(length:50)]
        public string Address { get; set; }
        [DataType(DataType.Date)]
        [Display(Name = "Date of Birth")]
        [Required(ErrorMessage = "Birth Date is mandatory.")]
        [DisplayFormat(ApplyFormatInEditMode =true,DataFormatString ="{0:yyyy-MM-dd}")]
        public Nullable<DateTime> BirthDate { get; set; }
        [Display(Name = "Mobile Number")]
        [Required(ErrorMessage = "Mobile number is mandatory.")]
        [DataType(DataType.PhoneNumber)]
        [MaxLength(length:10,ErrorMessage ="Mobile number must be 10 digits")]
        public string Mobileno { get; set; }
        [Display(Name = "Email Id")]
        [DataType(DataType.EmailAddress)]
        [Required(ErrorMessage = "Email is mandatory.")]
        public string Email { get; set; }
        [Required(ErrorMessage = "Password is mandatory.")]
        [DataType(DataType.Password)]
        [RegularExpression(@"(?=^.{8,}$)((?=.*\d)|(?=.*\W+))(?![.\n])(?=.*[A-Z])(?=.*[a-z]).*$", ErrorMessage ="Password is week")]
        public string Password { get; set; }
        [Required(ErrorMessage = "Gender is mandatory.")]
        public string Gender { get; set; }
        [Required(ErrorMessage = "Hobbies is mandatory.")]
        public string Hobbies { get; set; }
        [Required]
        [Display(Name ="Department")]
        public int DepartmentId { get; set; }
       
    }
}