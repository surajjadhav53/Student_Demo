using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services;

namespace Student_Demo
{
    /// <summary>
    /// Summary description for StudentService
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // To allow this Web Service to be called from script, using ASP.NET AJAX, uncomment the following line. 
    // [System.Web.Script.Services.ScriptService]
    public class StudentService : System.Web.Services.WebService
    {

        [WebMethod]
        public string HelloWorld()
        {
            return "Hello World";
        }
        [WebMethod]
        public bool IsValidUser(string UserName, string Password)
        {
            using (var ctx = new DB_STUDENTEntities2())
            {
                var stud = ctx.tblStudents.Where(w => w.Email == UserName && w.Password == Password).FirstOrDefault();

                // var Oldobj = ctx.tblStudents.Where(w => w.Email == obj.UserName && w.Password == obj.Password).FirstOrDefault();
                if (stud != null)
                {
                    return true;
                }
                return false;
            }
        }
        //[WebMethod]
        //public Student GetStudent(int id)
        //{

        //    using (var ctx = new DB_STUDENTEntities2())
        //    {
        //        var stud = ctx.tblStudents.Where(w => w.Id == id).FirstOrDefault();

        //        // var Oldobj = ctx.tblStudents.Where(w => w.Email == obj.UserName && w.Password == obj.Password).FirstOrDefault();
        //        if (stud != null)
        //        {
        //            Student st = new Student();

        //            st.Name = stud.Name;
        //            return stud;
        //        }
        //        return null;
        //    }

        //}

    }
}
