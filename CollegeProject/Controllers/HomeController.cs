using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using CollegeProject.DAL;

namespace CollegeProject.Controllers
{
    public class HomeController : Controller
    {
        private CollegeContext db = new CollegeContext();

        public ActionResult Index()
        {
            return View();
        }

        public ActionResult About()
        {
            return View();
        }

        public ActionResult Contact()
        {
            return View();
        }

        public ActionResult Statistics()
        {
            return View();
        }

        public ActionResult GraphOfStaff()
        {
            return View();
        }

        public ActionResult GraphOfCourses()
        {
            return View();
        }

        public ActionResult StudentsMap()
        {
            return View();
        }

        public class Result
        {
            public string Filter { get; set; }
            public int Amount { get; set; }
        }



        //graph
        public JsonResult StaffGraph()
        {

            List<Result> numOfCourses = new List<Result>();


            var query = from y in db.Courses
                        join l in db.StaffPeople on y.CourseID equals l.Course.CourseID
                        select y;


            //group for the graph
            var group = from x in query
                        group x by x.Title into cat
                        select new
                        {
                            Title = cat.Key,
                            Num = cat.Count()
                        };

            foreach (var item in group)
            {
                Result numCourses = new Result();
                numCourses.Filter = item.Title;
                numCourses.Amount = item.Num;


                numOfCourses.Add(numCourses);
            }

            return Json(numOfCourses, JsonRequestBehavior.AllowGet);
        }


        public JsonResult CoursesGraph()
        {

            List<Result> numOfCourses = new List<Result>();


            var query = from y in db.Faculties
                        join l in db.Courses on y.FacultyID equals l.Faculty.FacultyID
                        select y;


            //group for the graph
            var group = from x in query
                        group x by x.FacultyName into cat
                        select new
                        {
                            Name = cat.Key,
                            Num = cat.Count()
                        };

            foreach (var item in group)
            {
                Result numCourses = new Result();
                numCourses.Filter = item.Name;
                numCourses.Amount = item.Num;


                numOfCourses.Add(numCourses);
            }

            return Json(numOfCourses, JsonRequestBehavior.AllowGet);
        }

        //maps
        public JsonResult getAddresses()
        {
            List<string> addressList = new List<string>();

            foreach (var item in db.Students)
            {
                if (!String.IsNullOrEmpty(item.Address))
                {
                    addressList.Add(item.Address);
                }
            }
            return Json(addressList, JsonRequestBehavior.AllowGet);
        }
    }
}