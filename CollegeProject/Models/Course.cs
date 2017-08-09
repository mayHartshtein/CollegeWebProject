using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CollegeProject.Models
{
    public class Course
    {
        [Key]        
        public int CourseID { get; set; }
        public int FacultyID { get; set; }

        [DisplayName("Title")]
        public string Title { get; set; }

        [DisplayName("Description")]
        public string Description { get; set; }

        [DisplayName("Credits")]
        public int Credits { get; set; }

        [ForeignKey("FacultyID")]
        public virtual Faculty Faculty { get; set; }
        public virtual ICollection<Student> RegisteredStudents { get; set; }
        public virtual ICollection<StaffPerson> Staff { get; set; }
    }
}