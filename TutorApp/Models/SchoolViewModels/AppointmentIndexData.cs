using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TutorApp.Models.SchoolViewModels
{
    public class AppointmentIndexData
    {
        public IEnumerable<Appointment> Appointments { get; set; }
        public IEnumerable<Student> Students { get; set; }
        public IEnumerable<Tutor> Tutors { get; set; }
        public IEnumerable<Course> Courses { get; set; }
    }
}
