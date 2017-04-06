using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace TutorApp.Models
{
    public class Student : Person
    {
        public ICollection<Appointment> Appointments { get; set; } 
    }
}