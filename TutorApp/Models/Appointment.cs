using System;
using System.Collections.Generic;


namespace TutorApp.Models
{
    public enum Attended
    {
        Y, N
    }

    public class Appointment
    {
        public int AppointmentID { get; set; }
        public int CourseID { get; set; }
        public int StudentID { get; set; }
        public DateTime? AppointmentDate { get; set; }
        public DateTime? AppointmentTime { get; set; }
        public Attended? Attended { get; set; }

        public Course Course { get; set; }
        public Student Student { get; set; }
    }
}