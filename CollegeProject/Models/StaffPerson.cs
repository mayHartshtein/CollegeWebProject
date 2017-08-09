using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CollegeProject.Models
{
    public enum Job
    {
        Lecturer, Teaching_Assistant
    }
    public class StaffPerson
    {
        [Key]
        public int StaffPersonID { get; set; }
        public int CourseID { get; set; }

        [DisplayName("First Name")]
        public string FirstName { get; set; }

        [DisplayName("Last Name")]
        public string LastName { get; set; }

        [DisplayName("Role")]
        public Job Role { get; set; }

        [ForeignKey("CourseID")]
        public virtual Course Course { get; set; }
    }
}