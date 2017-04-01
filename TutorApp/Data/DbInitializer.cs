using TutorApp.Models;
using System;
using System.Linq;

namespace TutorApp.Data
{
    public static class DbInitializer
    {
        public static void Initialize(TutorContext context)
        {
            context.Database.EnsureCreated();

            // Look for any students.
            if (context.Students.Any())
            {
                return;   // DB has been seeded
            }

            var students = new Student[]
            {
            new Student{FirstName="Carson",LastName="Alexander",Email="AlexanderC@CoolSchool.edu",PhoneNumber=5551234567},
            new Student{FirstName="Meredith",LastName="Alonso",Email="AlonsoM@CoolSchool.edu",PhoneNumber=5551234567},
            new Student{FirstName="Arturo",LastName="Anand",Email="AnandA@CoolSchool.edu",PhoneNumber=5551234567},
            new Student{FirstName="Gytis",LastName="Barzdukas",Email="BarzdukasG@CoolSchool.edu",PhoneNumber=5551234567},
            new Student{FirstName="Yan",LastName="Li",Email="LiY@CoolSchool.edu",PhoneNumber=5551234567},
            new Student{FirstName="Peggy",LastName="Justice",Email="JusticeP@CoolSchool.edu",PhoneNumber=5551234567},
            new Student{FirstName="Laura",LastName="Norman",Email="NormanL@CoolSchool.edu",PhoneNumber=5551234567},
            new Student{FirstName="Nino",LastName="Olivetto",Email="OlivettoM@CoolSchool.edu",PhoneNumber=5551234567}
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
                    TutorID  = tutors.Single( i => i.LastName == "Abercrombie").TutorID },
                new Department { Name = "Mathematics",
                    StartDate = DateTime.Parse("2007-09-01"),
                    TutorID  = tutors.Single( i => i.LastName == "Fakhouri").TutorID },
                new Department { Name = "Engineering",
                    StartDate = DateTime.Parse("2007-09-01"),
                    TutorID  = tutors.Single( i => i.LastName == "Harui").TutorID },
                new Department { Name = "Economics",
                    StartDate = DateTime.Parse("2007-09-01"),
                    TutorID  = tutors.Single( i => i.LastName == "Kapoor").TutorID }
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
                    TutorID = tutors.Single( i => i.LastName == "Fakhouri").TutorID,
                    Location = "Smith 17" },
                new OfficeAssigned {
                    TutorID = tutors.Single( i => i.LastName == "Harui").TutorID,
                    Location = "Gowan 27" },
                new OfficeAssigned {
                    TutorID = tutors.Single( i => i.LastName == "Kapoor").TutorID,
                    Location = "Thompson 304" },
            };

            foreach (OfficeAssigned o in officeAssigned)
            {
                context.OfficeAssigned.Add(o);
            }
            context.SaveChanges();

            var courseTutors = new CourseAssigned[]
            {
                new CourseAssigned {
                    CourseID = courses.Single(c => c.Title == "Chemistry" ).CourseID,
                    TutorID = tutors.Single(i => i.LastName == "Kapoor").TutorID
                    },
                new CourseAssigned {
                    CourseID = courses.Single(c => c.Title == "Chemistry" ).CourseID,
                    TutorID = tutors.Single(i => i.LastName == "Harui").TutorID
                    },
                new CourseAssigned {
                    CourseID = courses.Single(c => c.Title == "Microeconomics" ).CourseID,
                    TutorID = tutors.Single(i => i.LastName == "Zheng").TutorID
                    },
                new CourseAssigned {
                    CourseID = courses.Single(c => c.Title == "Macroeconomics" ).CourseID,
                    TutorID = tutors.Single(i => i.LastName == "Zheng").TutorID
                    },
                new CourseAssigned {
                    CourseID = courses.Single(c => c.Title == "Calculus" ).CourseID,
                    TutorID = tutors.Single(i => i.LastName == "Fakhouri").TutorID
                    },
                new CourseAssigned {
                    CourseID = courses.Single(c => c.Title == "Trigonometry" ).CourseID,
                    TutorID = tutors.Single(i => i.LastName == "Harui").TutorID
                    },
                new CourseAssigned {
                    CourseID = courses.Single(c => c.Title == "Composition" ).CourseID,
                    TutorID = tutors.Single(i => i.LastName == "Abercrombie").TutorID
                    },
                new CourseAssigned {
                    CourseID = courses.Single(c => c.Title == "Literature" ).CourseID,
                    TutorID = tutors.Single(i => i.LastName == "Abercrombie").TutorID
                    },
            };

            foreach (CourseAssigned ci in courseTutors)
            {
                context.CourseAssigned.Add(ci);
            }
            context.SaveChanges();

            var appointments = new Appointment[]
            {
                    new Appointment {
                    StudentID = students.Single(s => s.LastName == "Alexander").StudentID,
                    CourseID = courses.Single(c => c.Title == "Chemistry" ).CourseID,
                    Attended = Attended.Y
                    },
                    new Appointment {
                    StudentID = students.Single(s => s.LastName == "Alexander").StudentID,
                    CourseID = courses.Single(c => c.Title == "Microeconomics" ).CourseID,
                    Attended = Attended.Y
                    },
                    new Appointment {
                    StudentID = students.Single(s => s.LastName == "Alexander").StudentID,
                    CourseID = courses.Single(c => c.Title == "Macroeconomics" ).CourseID,
                    Attended = Attended.N
                    },
                    new Appointment {
                        StudentID = students.Single(s => s.LastName == "Alonso").StudentID,
                    CourseID = courses.Single(c => c.Title == "Calculus" ).CourseID,
                    Attended = Attended.Y
                    },
                    new Appointment {
                        StudentID = students.Single(s => s.LastName == "Alonso").StudentID,
                    CourseID = courses.Single(c => c.Title == "Trigonometry" ).CourseID,
                    Attended = Attended.Y
                    },
                    new Appointment {
                    StudentID = students.Single(s => s.LastName == "Alonso").StudentID,
                    CourseID = courses.Single(c => c.Title == "Composition" ).CourseID,
                    Attended = Attended.N
                    },
                    new Appointment {
                    StudentID = students.Single(s => s.LastName == "Anand").StudentID,
                    CourseID = courses.Single(c => c.Title == "Chemistry" ).CourseID
                    },
                    new Appointment {
                    StudentID = students.Single(s => s.LastName == "Anand").StudentID,
                    CourseID = courses.Single(c => c.Title == "Microeconomics").CourseID,
                    Attended = Attended.N
                    },
                    new Appointment {
                    StudentID = students.Single(s => s.LastName == "Barzdukas").StudentID,
                    CourseID = courses.Single(c => c.Title == "Chemistry").CourseID,
                    Attended = Attended.N
                    },
                    new Appointment {
                    StudentID = students.Single(s => s.LastName == "Li").StudentID,
                    CourseID = courses.Single(c => c.Title == "Composition").CourseID,
                    Attended = Attended.Y
                    },
                    new Appointment {
                    StudentID = students.Single(s => s.LastName == "Justice").StudentID,
                    CourseID = courses.Single(c => c.Title == "Literature").CourseID,
                    Attended = Attended.Y
                    }
            };

            foreach (Appointment e in appointments)
            {
                var appointmentInDataBase = context.Appointments.Where(
                    s =>
                            s.Student.StudentID == e.StudentID &&
                            s.Course.CourseID == e.CourseID).SingleOrDefault();
                if (appointmentInDataBase == null)
                {
                    context.Appointments.Add(e);
                }
            }
            context.SaveChanges();
        }
    }
}