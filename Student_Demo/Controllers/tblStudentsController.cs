 using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Student_Demo;

namespace Student_Demo.Controllers
{
    public class tblStudentsController : Controller
    {
        private DB_STUDENTEntities2 db = new DB_STUDENTEntities2();

        // GET: tblStudents
        public ActionResult Index()
        {
            var tblStudents = db.tblStudents.Include(t => t.tblDepartment);
            return View(tblStudents.ToList());
        }

        // GET: tblStudents/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tblStudent tblStudent = db.tblStudents.Find(id);
            if (tblStudent == null)
            {
                return HttpNotFound();
            }
            return View(tblStudent);
        }

        // GET: tblStudents/Create
        public ActionResult Create()
        {
            ViewBag.DepartmentId = new SelectList(db.tblDepartments, "Id", "Name");
            return View();
        }

        // POST: tblStudents/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Name,Address,MobileNo,Gender,BirthDate,Email,Password,Hobbies,DepartmentId,Photo")] tblStudent tblStudent)
        {
            if (ModelState.IsValid)
            {
                db.tblStudents.Add(tblStudent);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.DepartmentId = new SelectList(db.tblDepartments, "Id", "Name", tblStudent.DepartmentId);
            return View(tblStudent);
        }

        // GET: tblStudents/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tblStudent tblStudent = db.tblStudents.Find(id);
            if (tblStudent == null)
            {
                return HttpNotFound();
            }
            ViewBag.DepartmentId = new SelectList(db.tblDepartments, "Id", "Name", tblStudent.DepartmentId);
            return View(tblStudent);
        }

        // POST: tblStudents/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Name,Address,MobileNo,Gender,BirthDate,Email,Password,Hobbies,DepartmentId,Photo")] tblStudent tblStudent)
        {
            if (ModelState.IsValid)
            {
                db.Entry(tblStudent).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.DepartmentId = new SelectList(db.tblDepartments, "Id", "Name", tblStudent.DepartmentId);
            return View(tblStudent);
        }

        // GET: tblStudents/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tblStudent tblStudent = db.tblStudents.Find(id);
            if (tblStudent == null)
            {
                return HttpNotFound();
            }
            return View(tblStudent);
        }

        // POST: tblStudents/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            tblStudent tblStudent = db.tblStudents.Find(id);
            db.tblStudents.Remove(tblStudent);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
