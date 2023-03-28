using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Student_Demo.IServices
{
    public interface IStudent
    {
        bool SaveStudent(tblStudent obj);

        List<tblStudent> GetAllStudents();
        tblStudent GetStudentById(int id);
        bool DeleteById(int id);

    }
}