using Student_Demo.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace Student_Demo.Controllers
{
    public class UserController : Controller
    {
        IServices.IStudent _student;
        public UserController(IServices.IStudent _stud)
        {
            _student = _stud;
        }
        // GET: User
        public ActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Index(Login obj)
        {

            //using (var ctx = new DB_STUDENTEntities2())
            //{
                var stud = _student.GetAllStudents().Where(w => w.Email == obj.UserName && w.Password == obj.Password).FirstOrDefault();

               // var Oldobj = ctx.tblStudents.Where(w => w.Email == obj.UserName && w.Password == obj.Password).FirstOrDefault();
                if (stud != null)
                {
                    Random rd = new Random();
                    int otp= rd.Next(1001, 9999);
                    //send otp on user mobile
                    TempData["UID"] = stud.Id;
                    TempData["OTP"] = otp;
                    return RedirectToAction("VerifyOtp");

                }
                else
                {
                    ViewBag.msg = "Invalid login credentials";
                }
            //}
            return View();
        }

        public ActionResult VerifyOtp()
        {
            return View();
        }
        [HttpPost]
        public ActionResult VerifyOtp(OtpVerification obj)
        {
            int Oldotp = Convert.ToInt32(TempData.Peek("OTP"));
            if (obj.OTP== Oldotp)
            {
                string UserId = TempData["UID"].ToString();
                FormsAuthentication.SetAuthCookie(UserId, false);
                return RedirectToAction("Create", "Student");
            }
            ViewBag.msg = "Entered otp is wrong.";
            return View();
        }
        public ActionResult Logout()
        {
            return RedirectToAction("Index");
        }
    }
}