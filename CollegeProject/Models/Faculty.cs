using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace CollegeProject.Models
{
    public class Faculty
    {
        [Key]
        public int FacultyID { get; set; }

        [DisplayName("Faculty Name")]
        public string FacultyName { get; set; }

        public virtual ICollection<Course> FacultyCourses { get; set; }
    }
}