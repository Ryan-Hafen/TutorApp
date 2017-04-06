using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using TutorApp.Data;

namespace TutorApp.Migrations
{
    [DbContext(typeof(TutorContext))]
    [Migration("20170402233743_newupdate")]
    partial class newupdate
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
            modelBuilder
                .HasAnnotation("ProductVersion", "1.1.1")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("TutorApp.Models.Appointment", b =>
                {
                    b.Property<int>("AppointmentID")
                        .ValueGeneratedOnAdd();

                    b.Property<DateTime?>("AppointmentDate");

                    b.Property<DateTime?>("AppointmentTime");

                    b.Property<int?>("Attended");

                    b.Property<int>("CourseID");

                    b.Property<int>("StudentID");

                    b.Property<int>("TutorID");

                    b.HasKey("AppointmentID");

                    b.HasIndex("CourseID");

                    b.HasIndex("StudentID");

                    b.HasIndex("TutorID");

                    b.ToTable("Appointment");
                });

            modelBuilder.Entity("TutorApp.Models.Course", b =>
                {
                    b.Property<int>("CourseID");

                    b.Property<int>("Credits");

                    b.Property<int>("DepartmentID");

                    b.Property<string>("Title")
                        .HasMaxLength(50);

                    b.HasKey("CourseID");

                    b.HasIndex("DepartmentID");

                    b.ToTable("Course");
                });

            modelBuilder.Entity("TutorApp.Models.CourseAssigned", b =>
                {
                    b.Property<int>("CourseID");

                    b.Property<int>("TutorID");

                    b.HasKey("CourseID", "TutorID");

                    b.HasIndex("TutorID");

                    b.ToTable("CourseAssigned");
                });

            modelBuilder.Entity("TutorApp.Models.Department", b =>
                {
                    b.Property<int>("DepartmentID")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Name")
                        .HasMaxLength(50);

                    b.Property<byte[]>("RowVersion")
                        .IsConcurrencyToken()
                        .ValueGeneratedOnAddOrUpdate();

                    b.Property<DateTime>("StartDate");

                    b.Property<int?>("TutorID");

                    b.HasKey("DepartmentID");

                    b.HasIndex("TutorID");

                    b.ToTable("Department");
                });

            modelBuilder.Entity("TutorApp.Models.OfficeAssigned", b =>
                {
                    b.Property<int>("TutorID");

                    b.Property<string>("Location")
                        .HasMaxLength(50);

                    b.HasKey("TutorID");

                    b.ToTable("OfficeAssigned");
                });

            modelBuilder.Entity("TutorApp.Models.Person", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Discriminator")
                        .IsRequired();

                    b.Property<string>("Email")
                        .IsRequired();

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasColumnName("FirstName")
                        .HasMaxLength(50);

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasMaxLength(50);

                    b.Property<long>("PhoneNumber");

                    b.HasKey("ID");

                    b.ToTable("Person");

                    b.HasDiscriminator<string>("Discriminator").HasValue("Person");
                });

            modelBuilder.Entity("TutorApp.Models.Student", b =>
                {
                    b.HasBaseType("TutorApp.Models.Person");


                    b.ToTable("Student");

                    b.HasDiscriminator().HasValue("Student");
                });

            modelBuilder.Entity("TutorApp.Models.Tutor", b =>
                {
                    b.HasBaseType("TutorApp.Models.Person");

                    b.Property<DateTime>("HireDate");

                    b.ToTable("Tutor");

                    b.HasDiscriminator().HasValue("Tutor");
                });

            modelBuilder.Entity("TutorApp.Models.Appointment", b =>
                {
                    b.HasOne("TutorApp.Models.Course", "Course")
                        .WithMany("Appointments")
                        .HasForeignKey("CourseID")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("TutorApp.Models.Student", "Student")
                        .WithMany("Appointments")
                        .HasForeignKey("StudentID")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("TutorApp.Models.Tutor", "Tutor")
                        .WithMany()
                        .HasForeignKey("TutorID")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("TutorApp.Models.Course", b =>
                {
                    b.HasOne("TutorApp.Models.Department", "Department")
                        .WithMany("Courses")
                        .HasForeignKey("DepartmentID")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("TutorApp.Models.CourseAssigned", b =>
                {
                    b.HasOne("TutorApp.Models.Course", "Course")
                        .WithMany("CourseAssigned")
                        .HasForeignKey("CourseID")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("TutorApp.Models.Tutor", "Tutor")
                        .WithMany("CourseAssigned")
                        .HasForeignKey("TutorID")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("TutorApp.Models.Department", b =>
                {
                    b.HasOne("TutorApp.Models.Tutor", "Administrator")
                        .WithMany()
                        .HasForeignKey("TutorID");
                });

            modelBuilder.Entity("TutorApp.Models.OfficeAssigned", b =>
                {
                    b.HasOne("TutorApp.Models.Tutor", "Tutor")
                        .WithOne("OfficeAssigned")
                        .HasForeignKey("TutorApp.Models.OfficeAssigned", "TutorID")
                        .OnDelete(DeleteBehavior.Cascade);
                });
        }
    }
}
