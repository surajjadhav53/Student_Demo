using Student_Demo.IServices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;

namespace Student_Demo.Service
{
    public class StudentRepo : IStudent
    {
        DB_STUDENTEntities2 ctx = new DB_STUDENTEntities2();
        public bool DeleteById(int id)
        {
            using (var ctx=new DB_STUDENTEntities2())
            {
                var obj = ctx.tblStudents.Find(id);
                if (obj!=null)
                {
                    ctx.tblStudents.Remove(obj);
                    ctx.SaveChanges();
                    return true;
                }
            }
            return false;
        }

        public List<tblStudent> GetAllStudents()
        {
            return ctx.tblStudents.Include(a => a.tblDepartment).ToList();
        }

        public tblStudent GetStudentById(int id)
        {
            return ctx.tblStudents.Find(id);
        }

        public bool SaveStudent(tblStudent obj)
        {
            try
            {
                ctx.tblStudents.Attach(obj);
                ctx.Entry(obj).State = obj.Id == 0 ? System.Data.Entity.EntityState.Added : System.Data.Entity.EntityState.Modified;

                ctx.SaveChanges();
                return true;
            }
            catch (Exception)
            {

                return false;
            }
        }

       
    }
}