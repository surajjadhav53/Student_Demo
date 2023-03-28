using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Student_Demo.Controllers
{
    public class DepartmentController : Controller
    {
        // GET: Department
        public ActionResult Index()
        {
            List<tblDepartment> Deptlist = new List<tblDepartment>();
            using (var ctx = new DB_STUDENTEntities2())
            {

                Deptlist = ctx.tblDepartments.ToList();

            }
            return View(Deptlist);
        }
        public ActionResult Create()
        {

            using (var ctx = new DB_STUDENTEntities2())
            {
                ViewBag.ListOfDepts = ctx.tblDepartments.ToList();
            }
            return View();
        }
        [HttpPost]
        public ActionResult Create(tblDepartment obj)
        {

            try
            {
                if (ModelState.IsValid == false)
                {
                    TempData["Message"] = "Deparment saved susseccfully.";
                    return View();

                }
                using (var ctx = new DB_STUDENTEntities2())
                {
                    ctx.tblDepartments.Add(obj);
                    ctx.SaveChanges();
                    //ViewBag.Message = "Deparment saved susseccfully.";
                    TempData["Message"] = "Deparment saved susseccfully.";
                    ViewBag.ListOfDepts = ctx.tblDepartments.ToList();
                }
               
            }
            catch (Exception er)
            {
                TempData["Message"] = "Ooops,went something wrong.";
                //  ViewBag.Message = "Ooops,went something wrong.";
            }
            return RedirectToAction("DepartmentList");
        }

        public ActionResult DepartmentList()
        {
            using (var ctx = new DB_STUDENTEntities2())
            {
                
               var list = ctx.tblDepartments.ToList();
                return View(list);
            }
           
        }
    }
}