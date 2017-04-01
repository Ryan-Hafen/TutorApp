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

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Course>().ToTable("Course");
            modelBuilder.Entity<Appointment>().ToTable("Appointment");
            modelBuilder.Entity<Student>().ToTable("Student");
        }
    }
}