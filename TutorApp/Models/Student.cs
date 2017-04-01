using System;
using System.Collections.Generic;

namespace TutorApp.Models
{
    public class Student
    {
        public int StudentID { get; set; }
        public string LastName { get; set; }
        public string FirstName { get; set; }
        public string Email { get; set; }
        public Int64 PhoneNumber { get; set; }

        public ICollection<Appointment> Appointments { get; set; }
    }
}