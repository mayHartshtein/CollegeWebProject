using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using CollegeProject.DAL;
using CollegeProject.Models;
using System.Data.Entity.Infrastructure;

namespace CollegeProject.Controllers
{
    public class StaffPersonController : Controller
    {
        private CollegeContext db = new CollegeContext();

        // GET: StaffPerson
        public ActionResult Index(string Name)
        {
            var staffPeople = db.StaffPeople.Include(s => s.Course);
            if (!String.IsNullOrEmpty(Name))
            {
                staffPeople = staffPeople.Where(s => s.LastName.Contains(Name)
                                       || s.FirstName.Contains(Name));
            }
            return View(staffPeople.ToList());
        }

        // GET: StaffPerson/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            StaffPerson staffPerson = db.StaffPeople.Find(id);
            if (staffPerson == null)
            {
                return HttpNotFound();
            }
            return View(staffPerson);
        }

        // GET: StaffPerson/Create
        public ActionResult Create()
        {
            PopulateStaffPersonsDropDownList();
            return View();
        }

        // POST: StaffPerson/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "StaffPersonID,CourseID,FirstName,LastName,Role")] StaffPerson staffPerson)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    db.StaffPeople.Add(staffPerson);
                    db.SaveChanges();
                    return RedirectToAction("Index");
                }
            }

            catch (RetryLimitExceededException /* dex */)
            {
                //Log the error (uncomment dex variable name and add a line here to write a log.)
                ModelState.AddModelError("", "Unable to save changes. Try again, and if the problem persists, see your system administrator.");
            }
            PopulateStaffPersonsDropDownList(staffPerson.CourseID);
            return View(staffPerson);
        }

        // GET: StaffPerson/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            StaffPerson staffPerson = db.StaffPeople.Find(id);
            if (staffPerson == null)
            {
                return HttpNotFound();
            }
            PopulateStaffPersonsDropDownList(staffPerson.CourseID);
            return View(staffPerson);
        }

        // POST: StaffPerson/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost, ActionName("Edit")]
        [ValidateAntiForgeryToken]
        public ActionResult EditPost(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var staffToUpdate = db.StaffPeople.Find(id);
            if (TryUpdateModel(staffToUpdate, "",
               new string[] { "FirstName", "LastName", "Role", "CourseID" }))
            {
                try
                {
                    db.SaveChanges();

                    return RedirectToAction("Index");
                }
                catch (RetryLimitExceededException /* dex */)
                {
                    //Log the error (uncomment dex variable name and add a line here to write a log.
                    ModelState.AddModelError("", "Unable to save changes. Try again, and if the problem persists, see your system administrator.");
                }
            }
            PopulateStaffPersonsDropDownList(staffToUpdate.CourseID);
            return View(staffToUpdate);
        }

        // GET: StaffPerson/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            StaffPerson staffPerson = db.StaffPeople.Find(id);
            if (staffPerson == null)
            {
                return HttpNotFound();
            }
            return View(staffPerson);
        }

        // POST: StaffPerson/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            StaffPerson staffPerson = db.StaffPeople.Find(id);
            db.StaffPeople.Remove(staffPerson);
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

        private void PopulateStaffPersonsDropDownList(object selectedCourse = null)
        {
            var coursesQuery = from d in db.Courses
                                   orderby d.Title
                                   select d;
            ViewBag.CourseID = new SelectList(coursesQuery, "CourseID", "Title", selectedCourse);
        }
    }
}
