using TutorApp.Models;
using Microsoft.EntityFrameworkCore;

namespace TutorApp.Data
{
    public class TutorContext : DbContext
    {
        public TutorContext(DbContextOptions<TutorContext> options) : base(options)
        {
        }

        public DbSet<Course> Courses { get; set; }
        public DbSet<Appointment> Appointments { get; set; }
        public DbSet<Student> Students { get; set; }
        public DbSet<Department> Departments { get; set; }
        public DbSet<Tutor> Tutors { get; set; }
        public DbSet<OfficeAssigned> OfficeAssigned { get; set; }
        public DbSet<CourseAssigned> CourseAssigned { get; set; }
        public DbSet<Person> People { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Course>().ToTable("Course");
            modelBuilder.Entity<Appointment>().ToTable("Appointment");
            modelBuilder.Entity<Student>().ToTable("Student");
            modelBuilder.Entity<Department>().ToTable("Department");
            modelBuilder.Entity<Tutor>().ToTable("Tutor");
            modelBuilder.Entity<OfficeAssigned>().ToTable("OfficeAssigned");
            modelBuilder.Entity<CourseAssigned>().ToTable("CourseAssigned");
            modelBuilder.Entity<Person>().ToTable("Person");

            modelBuilder.Entity<CourseAssigned>()
                .HasKey(c => new { c.CourseID, c.TutorID });
        }
    }
}