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

            var courses = new Course[]
            {
            new Course{CourseID=1050,Title="Chemistry",Credits=3,},
            new Course{CourseID=4022,Title="Microeconomics",Credits=3,},
            new Course{CourseID=4041,Title="Macroeconomics",Credits=3,},
            new Course{CourseID=1045,Title="Calculus",Credits=4,},
            new Course{CourseID=3141,Title="Trigonometry",Credits=4,},
            new Course{CourseID=2021,Title="Composition",Credits=3,},
            new Course{CourseID=2042,Title="Literature",Credits=4,}
            };
            foreach (Course c in courses)
            {
                context.Courses.Add(c);
            }
            context.SaveChanges();

            var Appointments = new Appointment[]
            {
            new Appointment{StudentID=1,CourseID=1050,AppointmentDate=DateTime.Parse("2017-03-18 14:57:32.8"),AppointmentTime=DateTime.Parse("2017-03-18 14:57:32.8"),Attended=Attended.Y},
            new Appointment{StudentID=1,CourseID=4022,AppointmentDate=DateTime.Parse("2017-03-18 14:57:32.8"),AppointmentTime=DateTime.Parse("2017-03-18 14:57:32.8"),Attended=Attended.Y},
            new Appointment{StudentID=1,CourseID=4041,AppointmentDate=DateTime.Parse("2017-03-18 14:57:32.8"),AppointmentTime=DateTime.Parse("2017-03-18 14:57:32.8"),Attended=Attended.Y},
            new Appointment{StudentID=2,CourseID=1045,AppointmentDate=DateTime.Parse("2017-03-18 14:57:32.8"),AppointmentTime=DateTime.Parse("2017-03-18 14:57:32.8"),Attended=Attended.N},
            new Appointment{StudentID=2,CourseID=3141,AppointmentDate=DateTime.Parse("2017-03-18 14:57:32.8"),AppointmentTime=DateTime.Parse("2017-03-18 14:57:32.8"),Attended=Attended.Y},
            new Appointment{StudentID=2,CourseID=2021,AppointmentDate=DateTime.Parse("2017-03-18 14:57:32.8"),AppointmentTime=DateTime.Parse("2017-03-18 14:57:32.8"),Attended=Attended.Y},
            new Appointment{StudentID=3,CourseID=1050,AppointmentDate=DateTime.Parse("2017-03-18 14:57:32.8"),AppointmentTime=DateTime.Parse("2017-03-18 14:57:32.8")},
            new Appointment{StudentID=4,CourseID=1050,AppointmentDate=DateTime.Parse("2017-03-18 14:57:32.8"),AppointmentTime=DateTime.Parse("2017-03-18 14:57:32.8")},
            new Appointment{StudentID=4,CourseID=4022,AppointmentDate=DateTime.Parse("2017-03-18 14:57:32.8"),AppointmentTime=DateTime.Parse("2017-03-18 14:57:32.8"),Attended=Attended.Y},
            new Appointment{StudentID=5,CourseID=4041,AppointmentDate=DateTime.Parse("2017-03-18 14:57:32.8"),AppointmentTime=DateTime.Parse("2017-03-18 14:57:32.8"),Attended=Attended.N},
            new Appointment{StudentID=6,CourseID=1045,AppointmentDate=DateTime.Parse("2017-03-18 14:57:32.8"),AppointmentTime=DateTime.Parse("2017-03-18 14:57:32.8")},
            new Appointment{StudentID=7,CourseID=3141,AppointmentDate=DateTime.Parse("2017-03-18 14:57:32.8"),AppointmentTime=DateTime.Parse("2017-03-18 14:57:32.8"),Attended=Attended.N},
            };
            foreach (Appointment a in Appointments)
            {
                context.Appointments.Add(a);
            }
            context.SaveChanges();
        }
    }
}