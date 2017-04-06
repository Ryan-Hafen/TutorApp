using System;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using TutorApp.Models;
using TutorApp.Data;

namespace ContosoUniversity.Data
{
    public static class DbInitializer
    {
        public static void Initialize(TutorContext context)
        {
            //context.Database.EnsureCreated();

            // Look for any students.
            if (context.Students.Any())
            {
                return;   // DB has been seeded
            }

            var students = new Student[]
            {
                new Student { FirstName = "Carson",   LastName = "Alexander"},
                new Student { FirstName = "Meredith", LastName = "Alonso"},
                new Student { FirstName = "Arturo",   LastName = "Anand"},
                new Student { FirstName = "Gytis",    LastName = "Barzdukas"},
                new Student { FirstName = "Yan",      LastName = "Li"},
                new Student { FirstName = "Peggy",    LastName = "Justice"},
                new Student { FirstName = "Laura",    LastName = "Norman"},
                new Student { FirstName = "Nino",     LastName = "Olivetto"}
            };

            foreach (Student s in students)
            {
                context.Students.Add(s);
            }
            context.SaveChanges();

            var tutors = new Tutor[]
            {
                new Tutor { FirstName = "Kim",     LastName = "Abercrombie",
                    HireDate = DateTime.Parse("1995-03-11") },
                new Tutor { FirstName = "Fadi",    LastName = "Fakhouri",
                    HireDate = DateTime.Parse("2002-07-06") },
                new Tutor { FirstName = "Roger",   LastName = "Harui",
                    HireDate = DateTime.Parse("1998-07-01") },
                new Tutor { FirstName = "Candace", LastName = "Kapoor",
                    HireDate = DateTime.Parse("2001-01-15") },
                new Tutor { FirstName = "Roger",   LastName = "Zheng",
                    HireDate = DateTime.Parse("2004-02-12") }
            };

            foreach (Tutor i in tutors)
            {
                context.Tutors.Add(i);
            }
            context.SaveChanges();

            var departments = new Department[]
            {
                new Department { Name = "English",    
                    StartDate = DateTime.Parse("2007-09-01"),
                    TutorID  = tutors.Single( i => i.LastName == "Abercrombie").ID },
                new Department { Name = "Mathematics",
                    StartDate = DateTime.Parse("2007-09-01"),
                    TutorID  = tutors.Single( i => i.LastName == "Fakhouri").ID },
                new Department { Name = "Engineering", 
                    StartDate = DateTime.Parse("2007-09-01"),
                    TutorID  = tutors.Single( i => i.LastName == "Harui").ID },
                new Department { Name = "Economics", 
                    StartDate = DateTime.Parse("2007-09-01"),
                    TutorID  = tutors.Single( i => i.LastName == "Kapoor").ID }
            };

            foreach (Department d in departments)
            {
                context.Departments.Add(d);
            }
            context.SaveChanges();

            var courses = new Course[]
            {
                new Course {CourseID = 1050, Title = "Chemistry",      Credits = 3,
                    DepartmentID = departments.Single( s => s.Name == "Engineering").DepartmentID
                },
                new Course {CourseID = 4022, Title = "Microeconomics", Credits = 3,
                    DepartmentID = departments.Single( s => s.Name == "Economics").DepartmentID
                },
                new Course {CourseID = 4041, Title = "Macroeconomics", Credits = 3,
                    DepartmentID = departments.Single( s => s.Name == "Economics").DepartmentID
                },
                new Course {CourseID = 1045, Title = "Calculus",       Credits = 4,
                    DepartmentID = departments.Single( s => s.Name == "Mathematics").DepartmentID
                },
                new Course {CourseID = 3141, Title = "Trigonometry",   Credits = 4,
                    DepartmentID = departments.Single( s => s.Name == "Mathematics").DepartmentID
                },
                new Course {CourseID = 2021, Title = "Composition",    Credits = 3,
                    DepartmentID = departments.Single( s => s.Name == "English").DepartmentID
                },
                new Course {CourseID = 2042, Title = "Literature",     Credits = 4,
                    DepartmentID = departments.Single( s => s.Name == "English").DepartmentID
                },
            };

            foreach (Course c in courses)
            {
                context.Courses.Add(c);
            }
            context.SaveChanges();

            var officeAssigned = new OfficeAssigned[]
            {
                new OfficeAssigned {
                    TutorID = tutors.Single( i => i.LastName == "Fakhouri").ID,
                    Location = "Smith 17" },
                new OfficeAssigned {
                    TutorID = tutors.Single( i => i.LastName == "Harui").ID,
                    Location = "Gowan 27" },
                new OfficeAssigned {
                    TutorID = tutors.Single( i => i.LastName == "Kapoor").ID,
                    Location = "Thompson 304" },
            };

            foreach (OfficeAssigned o in officeAssigned)
            {
                context.OfficeAssigned.Add(o);
            }
            context.SaveChanges();

            var courseTutor = new CourseAssigned[]
            {
                new CourseAssigned {
                    CourseID = courses.Single(c => c.Title == "Chemistry" ).CourseID,
                    TutorID = tutors.Single(i => i.LastName == "Kapoor").ID
                    },
                new CourseAssigned {
                    CourseID = courses.Single(c => c.Title == "Chemistry" ).CourseID,
                    TutorID = tutors.Single(i => i.LastName == "Harui").ID
                    },
                new CourseAssigned {
                    CourseID = courses.Single(c => c.Title == "Microeconomics" ).CourseID,
                    TutorID = tutors.Single(i => i.LastName == "Zheng").ID
                    },
                new CourseAssigned {
                    CourseID = courses.Single(c => c.Title == "Macroeconomics" ).CourseID,
                    TutorID = tutors.Single(i => i.LastName == "Zheng").ID
                    },
                new CourseAssigned {
                    CourseID = courses.Single(c => c.Title == "Calculus" ).CourseID,
                    TutorID = tutors.Single(i => i.LastName == "Fakhouri").ID
                    },
                new CourseAssigned {
                    CourseID = courses.Single(c => c.Title == "Trigonometry" ).CourseID,
                    TutorID = tutors.Single(i => i.LastName == "Harui").ID
                    },
                new CourseAssigned {
                    CourseID = courses.Single(c => c.Title == "Composition" ).CourseID,
                    TutorID = tutors.Single(i => i.LastName == "Abercrombie").ID
                    },
                new CourseAssigned {
                    CourseID = courses.Single(c => c.Title == "Literature" ).CourseID,
                    TutorID = tutors.Single(i => i.LastName == "Abercrombie").ID
                    },
            };

            foreach (CourseAssigned ci in courseTutor)
            {
                context.CourseAssigned.Add(ci);
            }
            context.SaveChanges();

            var appointments = new Appointment[]
            {
            };

            foreach (Appointment e in appointments)
            {
                var appointmentsInDataBase = context.Appointments.Where(
                    s =>
                            s.Student.ID == e.StudentID &&
                            s.Course.CourseID == e.CourseID).SingleOrDefault();
                if (appointmentsInDataBase == null)
                {
                    context.Appointments.Add(e);
                }
            }
            context.SaveChanges();
        }
    }
}