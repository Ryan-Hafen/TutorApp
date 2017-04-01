using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TutorApp.Models
{
    public class CourseAssigned
    {
        public int TutorID { get; set; }
        public int CourseID { get; set; }
        public Tutor Tutor { get; set; }
        public Course Course { get; set; }
    }
}
