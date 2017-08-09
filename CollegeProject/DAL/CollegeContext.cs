using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using CollegeProject.Models;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;

namespace CollegeProject.DAL
{
    public class CollegeContext : DbContext
    {
        public CollegeContext() : base("CollegeContext")
        {
        }

        public DbSet<Student> Students { get; set; }
        public DbSet<Faculty> Faculties { get; set; }
        public DbSet<Course> Courses { get; set; }
        public DbSet<StaffPerson> StaffPeople { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
        }
    }
}