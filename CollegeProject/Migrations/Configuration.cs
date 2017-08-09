namespace CollegeProject.Migrations
{
    using CollegeProject.Models;
    using System;
    using System.Collections.Generic;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<CollegeProject.DAL.CollegeContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(CollegeProject.DAL.CollegeContext context)
        {
            try
            {


                var students = new List<Student>
            {
                new Student {FirstName = "Carson",   LastName = "Alexander",
                    Address="Ha-Psanter St 1,Rishon LeTsiyon", Username="Carson@gmail.com" },
                new Student {StudentID=501, FirstName = "Meredith", LastName = "Alonso",
                    Address="HaUgav St 8,Rishon LeTsiyon", Username="Meredith@gmail.com" },
                new Student {StudentID=502, FirstName = "Arturo",   LastName = "Anand",
                    Address="Ha-Gitit St 1,Rishon LeTsiyon", Username="Arturo@gmail.com" },
                new Student {StudentID=503, FirstName = "Gytis",    LastName = "Barzdukas",
                    Address="HaTof St 1,Rishon LeTsiyon", Username="Gytis@gmail.com" },
                new Student {StudentID=504, FirstName = "Yan",      LastName = "Li",
                    Address="Ha-Psanter St 8,Rishon LeTsiyon", Username="Yan@gmail.com" },
                new Student {StudentID=505, FirstName = "Peggy",    LastName = "Justice",
                    Address="HaTizmoret St 38,Rishon LeTsiyon", Username="Peggy@gmail.com" },
                new Student {StudentID=506, FirstName = "Laura",    LastName = "Norman",
                    Address="HaTizmoret St 2,Rishon LeTsiyon", Username="Laura@gmail.com" },
                new Student {StudentID=507, FirstName = "Nino",     LastName = "Olivetto",
                    Address="HaTizmoret St 24,Rishon LeTsiyon", Username="Nino@gmail.com" }
            };
                //students.ForEach(s => context.Students.AddOrUpdate(p => p.LastName, s));

                context.Students.AddRange(students);
                context.SaveChanges();

                var faculties = new List<Faculty>
            {
                new Faculty {FacultyName = "Chemistry", },
                new Faculty {FacultyName = "Math", },
                new Faculty {FacultyName = "Economics", },
                new Faculty {FacultyName = "English", }
            };

                //faculties.ForEach(s => context.Faculties.AddOrUpdate(p => p.FacultyName, s));
                context.Faculties.AddRange(faculties);
                context.SaveChanges();

                var courses = new List<Course>
            {
                new Course {Title = "Chemistry", Credits = 3, FacultyID = faculties.Single(s => s.FacultyName == "Chemistry").FacultyID, Description="Chemistry",},
                new Course {Title = "Micro", Credits = 3, FacultyID = faculties.Single(s => s.FacultyName == "Economics").FacultyID, Description="Microeconomics",},
                new Course {Title = "Macro", Credits = 3, FacultyID = faculties.Single(s => s.FacultyName == "Economics").FacultyID, Description="Macroeconomics",},
                new Course {Title = "Calculus", Credits = 4, FacultyID = faculties.Single(s => s.FacultyName == "Math").FacultyID, Description="Calculus",},
                new Course {Title = "Trigonometry", Credits = 4, FacultyID = faculties.Single(s => s.FacultyName == "Math").FacultyID, Description="Trigonometry",},
                new Course {Title = "Composition", Credits = 3, FacultyID = faculties.Single(s => s.FacultyName == "English").FacultyID, Description="Composition",},
                new Course {Title = "Literature", Credits = 4, FacultyID = faculties.Single(s => s.FacultyName == "English").FacultyID, Description="Literature",}
            };
                context.Courses.AddRange(courses);
                context.SaveChanges();

                var staffPersons = new List<StaffPerson>
            {
                new StaffPerson {CourseID = courses.Single(s => s.Title == "Chemistry").CourseID, FirstName="Yoav", LastName="Mill", Role=Job.Teaching_Assistant,},
                new StaffPerson {CourseID = courses.Single(s => s.Title == "Chemistry").CourseID, FirstName="Michal", LastName="Eco", Role=Job.Teaching_Assistant,},
                new StaffPerson {CourseID = courses.Single(s => s.Title == "Chemistry").CourseID, FirstName="Miri", LastName="Paskal", Role=Job.Lecturer,},
                new StaffPerson {CourseID = courses.Single(s => s.Title == "Micro").CourseID, FirstName="Shir", LastName="Twin", Role=Job.Teaching_Assistant,},
                new StaffPerson {CourseID = courses.Single(s => s.Title == "Micro").CourseID, FirstName="Shira", LastName="Twin", Role=Job.Lecturer,},
                new StaffPerson {CourseID = courses.Single(s => s.Title == "Macro").CourseID, FirstName="Shalom", LastName="Asayag", Role=Job.Teaching_Assistant,},
                new StaffPerson {CourseID = courses.Single(s => s.Title == "Macro").CourseID, FirstName="Liam", LastName="Asi", Role=Job.Lecturer,},
                new StaffPerson {CourseID = courses.Single(s => s.Title == "Calculus").CourseID, FirstName="Hen", LastName="Israeli", Role=Job.Teaching_Assistant,},
                new StaffPerson {CourseID = courses.Single(s => s.Title == "Calculus").CourseID, FirstName="Hana", LastName="Rosen", Role=Job.Lecturer,},
                new StaffPerson {CourseID = courses.Single(s => s.Title == "Trigonometry").CourseID, FirstName="Dor", LastName="Dadon", Role=Job.Lecturer,},
                new StaffPerson {CourseID = courses.Single(s => s.Title == "Composition").CourseID, FirstName="Shai", LastName="Sason", Role=Job.Teaching_Assistant,},
                new StaffPerson {CourseID = courses.Single(s => s.Title == "Literature").CourseID, FirstName="Elad", LastName="Hadad", Role=Job.Teaching_Assistant,},
                new StaffPerson {CourseID = courses.Single(s => s.Title == "Literature").CourseID, FirstName="Noam", LastName="Matok", Role=Job.Teaching_Assistant,},
            };
                context.StaffPeople.AddRange(staffPersons);
                context.SaveChanges();
            }
            catch (System.Data.Entity.Validation.DbEntityValidationException e)
            {
                var outputLines = new List<string>();
                foreach (var eve in e.EntityValidationErrors)
                {
                    outputLines.Add(string.Format(
                        "{0}: Entity of type \"{1}\" in state \"{2}\" has the following validation errors:",
                        DateTime.Now, eve.Entry.Entity.GetType().Name, eve.Entry.State));
                    foreach (var ve in eve.ValidationErrors)
                    {
                        outputLines.Add(string.Format(
                            "- Property: \"{0}\", Error: \"{1}\"",
                            ve.PropertyName, ve.ErrorMessage));
                    }
                }
                //Write to file
                System.IO.File.AppendAllLines(@"c:\temp\errors.txt", outputLines);
                throw;

                // Showing it on screen
                throw new Exception(string.Join(",", outputLines.ToArray()));
            }
        }
    }
}