using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;
using CollegeProject.Models;

namespace CollegeProject.DAL
{
    public class CollegeInitializer : System.Data.Entity.DropCreateDatabaseIfModelChanges<CollegeContext>
    {
        protected override void Seed(CollegeContext context)
        {
            var students = new List<Student>
            {
            new Student{FirstName="Carson",LastName="Alexander"},
            new Student{FirstName="Meredith",LastName="Alonso"},
            new Student{FirstName="Arturo",LastName="Anand"},
            new Student{FirstName="Gytis",LastName="Barzdukas"},
            new Student{FirstName="Yan",LastName="Li"},
            new Student{FirstName="Peggy",LastName="Justice"},
            new Student{FirstName="Laura",LastName="Norman"},
            new Student{FirstName="Nino",LastName="Olivetto"}
            };

            students.ForEach(s => context.Students.Add(s));
            context.SaveChanges();
            var faculties = new List<Faculty>
            {
            new Faculty{FacultyID=1000, FacultyName="Computer Science"},
            new Faculty{FacultyID=1001, FacultyName="Math"},
            new Faculty{FacultyID=1002, FacultyName="Biology"},
            };
            faculties.ForEach(s => context.Faculties.Add(s));
            context.SaveChanges();
            var courses = new List<Course>
            {
            new Course{CourseID=1050,Title="Chemistry",Credits=3,Description="bla bla"},
            new Course{CourseID=4022,Title="Microeconomics",Credits=3,Description="bla bla"},
            new Course{CourseID=4041,Title="Macroeconomics",Credits=3,Description="bla bla"},
            new Course{CourseID=1045,Title="Calculus",Credits=4,Description="bla bla"},
            new Course{CourseID=3141,Title="Trigonometry",Credits=4,Description="bla bla"},
            new Course{CourseID=2021,Title="Composition",Credits=3,Description="bla bla"},
            new Course{CourseID=2042,Title="Literature",Credits=4,Description="bla bla"}
            };
            courses.ForEach(s => context.Courses.Add(s));
            context.SaveChanges();
            
            var staffPeople = new List<StaffPerson>
            {
            new StaffPerson{FirstName="Shir",LastName="k", Role=Job.Lecturer},
            new StaffPerson{FirstName="Shiri",LastName="k", Role=Job.Lecturer},
            new StaffPerson{FirstName="Shira",LastName="k", Role=Job.Teaching_Assistant},
            };
            staffPeople.ForEach(s => context.StaffPeople.Add(s));
            context.SaveChanges();
        }
    }
}