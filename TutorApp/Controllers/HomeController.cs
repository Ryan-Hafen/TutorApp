using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using TutorApp.Data;
using TutorApp.Models.SchoolViewModels;
using Microsoft.EntityFrameworkCore;

namespace TutorApp.Controllers
{
    public class HomeController : Controller
    {
        private readonly TutorContext _context;

        public HomeController(TutorContext context)
        {
            _context = context;
        }
        public IActionResult Index()
        {
            return View();
        }

        public async Task<ActionResult> About()
        {
            IQueryable<AppointmentDateGroup> data =
                from appointment in _context.Appointments
                group appointment by appointment.AppointmentDate into dateGroup
                select new AppointmentDateGroup()
                {
                    AppointmentDates = dateGroup.Key,
                    AppointmentCount = dateGroup.Count()
                };
            return View(await data.AsNoTracking().ToListAsync());
        }

        public IActionResult Error()
        {
            return View();
        }
    }
}
