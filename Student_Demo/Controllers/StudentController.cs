using Student_Demo.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data.Entity;
using Student_Demo.IServices;
using Student_Demo.Service;

namespace Student_Demo.Controllers
{
    public class StudentController : Controller
    {
        IStudent _stud;
          public StudentController(IStudent _std)
        {
            _stud = _std;
        }
        // GET: Student

       [Route("NewStudent/{id?}")]
        [HttpGet]
       // [Authorize]
        public ActionResult Create(int id=0)
        {
            //using (var ctx = new DB_STUDENTEntities2())
            //{
            // ViewData["StdList"] = ctx.tblStudents.Include(a=>a.tblDepartment).ToList();
            ViewData["StdList"] = _stud.GetAllStudents().ToList();
                ViewBag.DepartmentList = clsCommon.GetDepartment();


            //}


            if (id==0)   //for create
            {
                //Student newStud = new Student();

                return View();
            }

            Student s1 = new Student();
            //using (var ctx = new DB_STUDENTEntities2())
            //{

                var obj = _stud.GetStudentById(id);
                if (obj != null)
                {
                    s1.Id = obj.Id;
                    s1.Name = obj.Name;
                    s1.Address = obj.Address;
                    s1.Gender = obj.Gender;
                    s1.BirthDate = Convert.ToDateTime(obj.BirthDate);
                    s1.Mobileno = obj.MobileNo;
                    s1.Email = obj.Email;
                    s1.Password = obj.Password;
                    s1.Hobbies = obj.Hobbies;
                }
              
            //}
            return View(s1);
        }
        [HttpPost]
       [Route("NewStudent/{id?}")] 
        public ActionResult Create(Student obj,HttpPostedFileBase myPhoto)
        {
            string FileName = "";
            if (myPhoto!=null)
            {
                
                string folderPath = Server.MapPath("~/Uploaded/");
                FileName = DateTime.Now.ToString("ddMMyyyyhhmmss")+myPhoto.FileName;
                myPhoto.SaveAs(folderPath + FileName );
            }


            ViewBag.DepartmentList = clsCommon.GetDepartment();


            tblStudent Stud = new tblStudent();
            Stud.Name = obj.Name;
            Stud.Address = obj.Address;
            Stud.Gender = obj.Gender;
            Stud.BirthDate = obj.BirthDate;
            Stud.MobileNo = obj.Mobileno;
            Stud.Email = obj.Email;
            Stud.Password = obj.Password;
            Stud.Hobbies = obj.Hobbies;
            Stud.DepartmentId = obj.DepartmentId;
            Stud.Photo = FileName;
            bool res= _stud.SaveStudent(Stud);
            if (true)
            {
                ViewData["Message"] = "Record updated successfully.";
            }
            else
            {
                ViewData["Message"] = "Failed";
            }
            //ctx.tblStudents.Add(Stud);
            //ctx.SaveChanges();
            //if (ModelState.IsValid)
            //{
            //using (var ctx = new DB_STUDENTEntities2())
            //    {
            //if (obj.Id>0)
            //{
            //    var OldStud = ctx.tblStudents.Find(obj.Id);
            //    if (OldStud != null)
            //    {
            //        OldStud.Name = obj.Name;
            //        OldStud.Address = obj.Address;
            //        OldStud.Gender = obj.Gender;
            //        OldStud.BirthDate = obj.BirthDate;
            //        OldStud.MobileNo = obj.Mobileno;
            //        OldStud.Email = obj.Email;
            //        OldStud.Password = obj.Password;
            //        OldStud.Hobbies = obj.Hobbies;
            //        OldStud.DepartmentId = obj.DepartmentId;
            //        OldStud.Photo = FileName;
            //        ctx.tblStudents.Attach(OldStud);
            //        ctx.Entry(OldStud).State = System.Data.Entity.EntityState.Modified;

            //        ctx.SaveChanges();
            //    }

            //    ViewData["Message"] = "Record updated successfully.";

            //}
            // else
            //{
            //    tblStudent Stud = new tblStudent();
            //    Stud.Name = obj.Name;
            //    Stud.Address = obj.Address;
            //    Stud.Gender = obj.Gender;
            //    Stud.BirthDate = obj.BirthDate;
            //    Stud.MobileNo = obj.Mobileno;
            //    Stud.Email = obj.Email;
            //    Stud.Password = obj.Password;
            //    Stud.Hobbies = obj.Hobbies;
            //    Stud.DepartmentId = obj.DepartmentId;
            //    Stud.Photo = FileName;
            //ctx.tblStudents.Add(Stud);
            //    ctx.SaveChanges();
            //ViewData["Message"] = "Record inserted successfully.";
            //}

            //}
            //  return RedirectToAction("Index");

            //}
            //using (var ctx = new DB_STUDENTEntities2())
            //{
            //    ViewData["StdList"] = ctx.tblStudents.Include(a => a.tblDepartment).ToList();

            //}

            //ModelState.Clear();
            //return View();
            return View();  
        }
        public ActionResult Index()
        {
            List<tblStudent> Studlist = _stud.GetAllStudents();
            //using (var ctx=new DB_STUDENTEntities2())
            //{

            //    Studlist = ctx.tblStudents.ToList(); 
                
            //}
            return View(Studlist);
        }
        //public ActionResult Edit(int id)
        //{
        //    Student s1 = new Student();
        //    using (var ctx=new DB_STUDENTEntities2())
        //    {
        //        var obj = ctx.tblStudents.Where(w => w.Id == id).FirstOrDefault();
        //        if (obj!=null)
        //        {
        //            s1.Id = obj.Id;
        //            s1.Name = obj.Name;
        //            s1.Address = obj.Address;
        //            s1.BirthDate = Convert.ToDateTime(obj.BirthDate);
        //            s1.Mobileno = obj.MobileNo;
        //            s1.Email = obj.Email;
        //            s1.Password = obj.Password;
        //        }
        //        else
        //        {
        //            return RedirectToAction("Index");
        //        }
               
        //    }
        //    return View(s1);
        //}
        //[HttpPost]
        //public ActionResult Edit(Student ModifiedStud)
        //{
        //    try
        //    {

           
        //    using (var ctx=new DB_STUDENTEntities2())
        //    {
        //        var OldStud = ctx.tblStudents.Find(ModifiedStud.Id);
        //        if (OldStud!=null)
        //        {
        //            OldStud.Name = ModifiedStud.Name;
        //            OldStud.Address = ModifiedStud.Address;
        //            OldStud.BirthDate = ModifiedStud.BirthDate;
        //            OldStud.MobileNo = ModifiedStud.Mobileno;
        //            OldStud.Email = ModifiedStud.Email;
        //            OldStud.Password = ModifiedStud.Password;
        //            ctx.tblStudents.Attach(OldStud);
        //            ctx.Entry(OldStud).State = System.Data.Entity.EntityState.Modified;
                  
        //            ctx.SaveChanges();
        //        }

               
        //    }
        //    }
        //    catch (Exception er)
        //    {

                
        //    }
        //    return RedirectToAction("Index");
        //}
        public ActionResult Delete(int Itemid)
        {
            //using (var ctx = new DB_STUDENTEntities2())
            //{
            _stud.DeleteById(Itemid);


            //}
            return RedirectToAction("Create",new { id=0});
        }
    }
}