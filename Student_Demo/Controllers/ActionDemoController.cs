using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data.Entity;
using Student_Demo.Models;
using System.Data.SqlClient;
using System.Data;

namespace Student_Demo.Controllers
{
    public class ActionDemoController : Controller
    {
        // GET: ActionDemo
        public ActionResult Index()
        {
            return RedirectToAction("Home");
        }
        public ContentResult getData()
        {
            return Content("Suraj gsgsd");
        
        }
        public JsonResult GetAllStudents()
        {
            //return Json("Suraj gsgsd",JsonRequestBehavior.AllowGet);
            using (var ctx=new DB_STUDENTEntities2())
            {
                var objlist = ctx.tblStudents.Select(s=>new { s.Id,s.Name,s.Address,s.Gender,s.MobileNo,s.Email,s.Password,s.Hobbies,Department=s.tblDepartment.Name}).ToList();
                return Json(objlist, JsonRequestBehavior.AllowGet);
            }
        }
        public JavaScriptResult getJs()
        {
            return JavaScript("<script>alert('ok')</script>");
        
        }
        public ActionResult DownloadPhoto(int id) 
        {
            using (var ctx=new DB_STUDENTEntities2())
            {
                var stud = ctx.tblStudents.Find(id);
                if (id!=null)
                {
                   // string FolderPath = Server.MapPath("~/Uploaded/");
                    string imgPath = "~/Uploaded/" + stud.Photo;
                    byte[] fileBytes = System.IO.File.ReadAllBytes(Server.MapPath(imgPath));
                    return File(fileBytes,"image/png", stud.Photo);

                }
            }
            return Content("<script>alert('file not found')</script>");
            
        }

        public ActionResult GetLoginView()
        {
            using (var ctx = new DB_STUDENTEntities2())
            {
                var olist = ctx.tblFooter1.OrderBy(o => o.SortOrder).Skip(10).Take(5).ToList();
                return PartialView("_Menu",olist);
            }
           // return PartialView("_LoginView");
        }
        public ActionResult Students(int PageNo=1)
        {
            int PageSize = 5;
            int skipCount = (PageNo-1)*PageSize;
            List<tblStudent> olist = new List<tblStudent>();
            using (var ctx=new DB_STUDENTEntities2())
            {
                int res= ctx.tblStudents.Count() / PageSize;
                if ((ctx.tblStudents.Count() % PageSize)!=0)
                {
                    res++;
                }
                ViewBag.TotalPages = res;
                olist = ctx.tblStudents.Include(I=>I.tblDepartment).OrderByDescending(o=>o.Id).Skip(skipCount).Take(PageSize).ToList();
            }
            return View(olist);
        }
        public ActionResult Footer()
        {
            ViewBag.allFooters = getAllFooters();
            return View();
        }

        [HttpPost]
        public ActionResult Footer(VMFooter _Footer)
        {
            using (var ctx=new DB_STUDENTEntities2())
            {
              




                SqlParameter DisplayText = new SqlParameter()
                {
                    ParameterName = "@DisplayText",
                    SqlDbType = SqlDbType.NVarChar,
                    Size = 50,
                    Value =_Footer.DisplayText
                };


                SqlParameter URL = new SqlParameter()
                {
                    ParameterName = "@URL",
                    SqlDbType = SqlDbType.NVarChar,
                    Size = 500,
                    Value = _Footer.LinkUrl
                };


                SqlParameter SortOrder = new SqlParameter()
                {
                    ParameterName = "@SortOrder",
                    SqlDbType = SqlDbType.Int,
                    Value = _Footer.SortOrder
                };



                SqlParameter ResCode = new SqlParameter()
                {
                    ParameterName = "@ResCode",
                    SqlDbType = SqlDbType.Int,
                    Value = 0,
                    Direction = ParameterDirection.InputOutput
                };



                SqlParameter Resmsg = new SqlParameter()
                {
                    ParameterName = "@Resmsg",
                    SqlDbType = SqlDbType.NVarChar,
                    Size = 8000,
                    Value = "",
                    Direction = ParameterDirection.InputOutput
                };





                ctx.Database.ExecuteSqlCommand("Exec InsertFooterLink @DisplayText, @URL, @SortOrder,@ResCode out,@Resmsg out",
                    DisplayText, URL, SortOrder, ResCode, Resmsg);

                ViewBag.msg = Resmsg.Value.ToString();
              
            }
            ViewBag.allFooters = getAllFooters();
            return View();
        }

        private dynamic getAllFooters()
        {
            List<VMFooter> VF = new List<VMFooter>();    
            using (var ctx =new DB_STUDENTEntities2())
            {

                VF = ctx.Database.SqlQuery<VMFooter>("Exec GetFooter ").ToList();

              

            }
            return VF;
        }
    }
}