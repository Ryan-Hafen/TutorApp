using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using TutorApp.Data;
using TutorApp.Models;
using TutorApp.Models.SchoolViewModels;

namespace TutorApp.Controllers
{
    public class AppointmentsController : Controller
    {
        private readonly TutorContext _context;

        public AppointmentsController(TutorContext context)
        {
            _context = context;
        }

        // GET: Appointments
        public async Task<IActionResult> Index(int? id)
        {
            var viewModel = new AppointmentIndexData();
            viewModel.Appointments = await _context.Appointments
                  .Include(i => i.Student)
                  .Include(i => i.Tutor)
                  .Include(i => i.Course)
                  .AsNoTracking()
                  .OrderBy(i => i.AppointmentDate)
                  .ToListAsync();

            if (id != null)
            {
                ViewData["AppointmentID"] = id.Value;
                Appointment appointment = viewModel.Appointments.Where(
                    i => i.AppointmentID == id.Value).Single();

            }

            return View(viewModel);
        }
    }
}