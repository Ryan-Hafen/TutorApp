using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace TutorApp.Models.SchoolViewModels
{
    public class AppointmentDateGroup
    {
        [DataType(DataType.Date)]
        public DateTime? AppointmentDates { get; set; }

        public int AppointmentCount { get; set; }
    }
}
