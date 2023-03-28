using AutoMapper;
using Student_Demo.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Student_Demo.Controllers
{
    public class FooterController : Controller
    {
        Mapper mapper = null;
        public FooterController()
        {
            var config = new MapperConfiguration(c => c.CreateMap<ViewModelFooter, tblFooter1>().ReverseMap());
             mapper = new Mapper(config);

        }
        // GET: Footer
        public ActionResult Create(int id=0)
    {
            if (id==0)
            {
                return View();
            }
            using (var ctx = new DB_STUDENTEntities2())
            {
               var obj=ctx.tblFooter1.Find(id);
                if (obj!=null)
                {
                    ViewModelFooter vmFooter = mapper.Map<tblFooter1, ViewModelFooter>(obj);
                    return View(vmFooter);
                }
                ctx.SaveChanges();
            }
            return View();
        }
        [HttpPost]
        public ActionResult Create(ViewModelFooter _Footer)
        {
           
            tblFooter1 obj = mapper.Map<ViewModelFooter, tblFooter1>(_Footer);
            using (var ctx=new DB_STUDENTEntities2())
            {
                ctx.tblFooter1.Add(obj);
                ctx.SaveChanges();
            }
            return View();
        }
        public ActionResult Index()
        {
            List<ViewModelFooter> Flist = new List<ViewModelFooter>();
            using (var ctx = new DB_STUDENTEntities2())
            {
                var objlist = ctx.tblFooter1.ToList();
                Flist = mapper.Map<List<tblFooter1>, List<ViewModelFooter>>(objlist);
            }
            return View(Flist);
        }
        public ActionResult ViewData()
        {
            VMViewData odata = new VMViewData();
            using (var ctx = new DB_STUDENTEntities2())
            {
                odata.Footer = ctx.tblFooter1.ToList();
                odata.Department = ctx.tblDepartments.ToList();
            }
            return View(odata);
        }
    }
}