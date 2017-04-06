using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TutorApp.Models.SchoolViewModels
{
    public class TutorIndexData
    {
        public IEnumerable<Tutor> Tutors { get; set; }
        public IEnumerable<Course> Courses { get; set; }
        public IEnumerable<Appointment> Appointments { get; set; }
    }
}