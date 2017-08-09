namespace CollegeProject.Migrations
{
    using System;
    using System.Data.Entity.Migrations;

    public partial class InitialCreate : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Course",
                c => new
                {
                    CourseID = c.Int(nullable: false, identity: true),
                    FacultyID = c.Int(nullable: false),
                    Title = c.String(nullable: false),
                    Description = c.String(nullable: false),


                    Credits = c.Int(nullable: false),
                })
                .PrimaryKey(t => t.CourseID)
                .ForeignKey("dbo.Faculty", t => t.FacultyID, cascadeDelete: true)
                .Index(t => t.FacultyID);

            CreateTable(
                "dbo.Faculty",
                c => new
                {
                    FacultyID = c.Int(nullable: false, identity: true),
                    FacultyName = c.String(nullable: false),

                })
                .PrimaryKey(t => t.FacultyID);

            CreateTable(
                "dbo.Student",
                c => new
                {
                    StudentID = c.Int(nullable: false, identity: true),
                    Username = c.String(nullable: false),
                    FirstName = c.String(nullable: false),
                    LastName = c.String(nullable: false),
                    Address = c.String(nullable: false),



                })
                .PrimaryKey(t => t.StudentID);

            CreateTable(
                "dbo.StaffPerson",
                c => new
                {
                    StaffPersonID = c.Int(nullable: false, identity: true),
                    CourseID = c.Int(nullable: false),
                    FirstName = c.String(nullable: false),
                    LastName = c.String(nullable: false),
                    Role = c.Int(nullable: false),



                })
                .PrimaryKey(t => t.StaffPersonID)
                .ForeignKey("dbo.Course", t => t.CourseID, cascadeDelete: true)
                .Index(t => t.CourseID);

            CreateTable(
                "dbo.StudentCourse",
                c => new
                {
                    Student_StudentID = c.Int(nullable: false),
                    Course_CourseID = c.Int(nullable: false),
                })
                .PrimaryKey(t => new { t.Student_StudentID, t.Course_CourseID })
                .ForeignKey("dbo.Student", t => t.Student_StudentID, cascadeDelete: true)
                .ForeignKey("dbo.Course", t => t.Course_CourseID, cascadeDelete: true)
                .Index(t => t.Student_StudentID)
                .Index(t => t.Course_CourseID);

        }

        public override void Down()
        {
            DropForeignKey("dbo.StaffPerson", "CourseID", "dbo.Course");
            DropForeignKey("dbo.StudentCourse", "Course_CourseID", "dbo.Course");
            DropForeignKey("dbo.StudentCourse", "Student_StudentID", "dbo.Student");
            DropForeignKey("dbo.Course", "FacultyID", "dbo.Faculty");
            DropIndex("dbo.StudentCourse", new[] { "Course_CourseID" });
            DropIndex("dbo.StudentCourse", new[] { "Student_StudentID" });
            DropIndex("dbo.StaffPerson", new[] { "CourseID" });
            DropIndex("dbo.Course", new[] { "FacultyID" });
            DropTable("dbo.StudentCourse");
            DropTable("dbo.StaffPerson");
            DropTable("dbo.Student");
            DropTable("dbo.Faculty");
            DropTable("dbo.Course");
        }
    }
}
