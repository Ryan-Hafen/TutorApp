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
    public class TutorsController : Controller
    {
        private readonly TutorContext _context;

        public TutorsController(TutorContext context)
        {
            _context = context;
        }

        // GET: Tutors
        public async Task<IActionResult> Index(int? id, int? courseID)
        {
            var viewModel = new TutorIndexData();
            viewModel.Tutors = await _context.Tutors
                  .Include(i => i.OfficeAssigned)
                  .Include(i => i.CourseAssigned)
                    .ThenInclude(i => i.Course)
                        .ThenInclude(i => i.Appointments)
                            .ThenInclude(i => i.Student)
                  .Include(i => i.CourseAssigned)
                    .ThenInclude(i => i.Course)
                        .ThenInclude(i => i.Department)
                  .AsNoTracking()
                  .OrderBy(i => i.LastName)
                  .ToListAsync();

            if (id != null)
            {
                ViewData["TutorID"] = id.Value;
                Tutor tutor = viewModel.Tutors.Where(
                    i => i.ID == id.Value).Single();
                viewModel.Courses = tutor.CourseAssigned.Select(s => s.Course);
            }

            if (courseID != null)
            {
                ViewData["CourseID"] = courseID.Value;
                viewModel.Appointments = viewModel.Courses.Where(
                    x => x.CourseID == courseID).Single().Appointments;
            }

            return View(viewModel);
        }

        // GET: Tutors/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tutor = await _context.Tutors
                .SingleOrDefaultAsync(m => m.ID == id);
            if (tutor == null)
            {
                return NotFound();
            }

            return View(tutor);
        }

        // GET: Tutors/Create
        public IActionResult Create()
        {
            var tutor = new Tutor();
            tutor.CourseAssigned = new List<CourseAssigned>();
            PopulateAssignedCourseData(tutor);
            return View();
        }

        // POST: Tutors/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("FirstName,HireDate,LastName,OfficeAssigned")] Tutor tutor, string[] selectedCourses)
        {
            if (selectedCourses != null)
            {
                tutor.CourseAssigned = new List<CourseAssigned>();
                foreach (var course in selectedCourses)
                {
                    var courseToAdd = new CourseAssigned { TutorID = tutor.ID, CourseID = int.Parse(course) };
                    tutor.CourseAssigned.Add(courseToAdd);
                }
            }
            if (ModelState.IsValid)
            {
                _context.Add(tutor);
                await _context.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            return View(tutor);
        }

        // GET: Tutors/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tutor = await _context.Tutors
                .Include(i => i.OfficeAssigned)
                .Include(i => i.CourseAssigned).ThenInclude(i => i.Course)
                .AsNoTracking()
                .SingleOrDefaultAsync(m => m.ID == id);
            if (tutor == null)
            {
                return NotFound();
            }
            PopulateAssignedCourseData(tutor);
            return View(tutor);
        }

        private void PopulateAssignedCourseData(Tutor tutor)
        {
            var allCourses = _context.Courses;
            var tutorCourses = new HashSet<int>(tutor.CourseAssigned.Select(c => c.Course.CourseID));
            var viewModel = new List<AssignedCourseData>();
            foreach (var course in allCourses)
            {
                viewModel.Add(new AssignedCourseData
                {
                    CourseID = course.CourseID,
                    Title = course.Title,
                    Assigned = tutorCourses.Contains(course.CourseID)
                });
            }
            ViewData["Courses"] = viewModel;
        }

        // POST: Tutors/Edit/5
        [HttpPost, ActionName("Edit")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int? id, string[] selectedCourses)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tutorToUpdate = await _context.Tutors
                .Include(i => i.OfficeAssigned)
                .Include(i => i.CourseAssigned)
                    .ThenInclude(i => i.Course)
                .SingleOrDefaultAsync(s => s.ID == id);

            if (await TryUpdateModelAsync<Tutor>(
                tutorToUpdate,
                "",
                i => i.FirstName, i => i.LastName, i => i.HireDate, i => i.OfficeAssigned))
            {
                if (String.IsNullOrWhiteSpace(tutorToUpdate.OfficeAssigned?.Location))
                {
                    tutorToUpdate.OfficeAssigned = null;
                }
                UpdateTutorCourses(selectedCourses, tutorToUpdate);
                try
                {
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateException /* ex */)
                {
                    //Log the error (uncomment ex variable name and write a log.)
                    ModelState.AddModelError("", "Unable to save changes. " +
                        "Try again, and if the problem persists, " +
                        "see your system administrator.");
                }
                return RedirectToAction("Index");
            }
            return View(tutorToUpdate);
        }
        private void UpdateTutorCourses(string[] selectedCourses, Tutor tutorToUpdate)
        {
            if (selectedCourses == null)
            {
                tutorToUpdate.CourseAssigned = new List<CourseAssigned>();
                return;
            }

            var selectedCoursesHS = new HashSet<string>(selectedCourses);
            var tutorCourses = new HashSet<int>
                (tutorToUpdate.CourseAssigned.Select(c => c.Course.CourseID));
            foreach (var course in _context.Courses)
            {
                if (selectedCoursesHS.Contains(course.CourseID.ToString()))
                {
                    if (!tutorCourses.Contains(course.CourseID))
                    {
                        tutorToUpdate.CourseAssigned.Add(new CourseAssigned { TutorID = tutorToUpdate.ID, CourseID = course.CourseID });
                    }
                }
                else
                {

                    if (tutorCourses.Contains(course.CourseID))
                    {
                        CourseAssigned courseToRemove = tutorToUpdate.CourseAssigned.SingleOrDefault(i => i.CourseID == course.CourseID);
                        _context.Remove(courseToRemove);
                    }
                }
            }
        }

        // GET: Tutors/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tutor = await _context.Tutors
                .SingleOrDefaultAsync(m => m.ID == id);
            if (tutor == null)
            {
                return NotFound();
            }

            return View(tutor);
        }

        // POST: Tutors/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            Tutor tutor = await _context.Tutors
                .Include(i => i.CourseAssigned)
                .SingleAsync(i => i.ID == id);

            var departments = await _context.Departments
                .Where(d => d.TutorID == id)
                .ToListAsync();
            departments.ForEach(d => d.TutorID = null);

            _context.Tutors.Remove(tutor);

            await _context.SaveChangesAsync();
            return RedirectToAction("Index");
        }
    }
}
