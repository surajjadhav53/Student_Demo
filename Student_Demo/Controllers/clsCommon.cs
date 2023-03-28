using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Student_Demo.Controllers
{
    public static class clsCommon
    {

        public static string GetFullName(int Id)
        {
            using (var ctx = new DB_STUDENTEntities2())
            {
                var obj = ctx.tblStudents.Find(Id);
                if (obj!=null)
                {
                    return obj.Name;
                }
            }
                return "";
          
        }

        public static List<SelectListItem> GetDepartment()
        {
            List<SelectListItem> depts = new List<SelectListItem>();
            using (var ctx = new DB_STUDENTEntities2())
            {
                var alldepts = ctx.tblDepartments.ToList();
                foreach (var item in alldepts)
                {
                    depts.Add(new SelectListItem() { Text = item.Name, Value = item.Id.ToString() });
                }
                return depts;


            }
        }
    }
}