using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Metadata;

namespace TutorApp.Migrations
{
    public partial class update : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Appointment_Person_ID",
                table: "Appointment");

            migrationBuilder.DropForeignKey(
                name: "FK_CourseAssigned_Person_ID",
                table: "CourseAssigned");

            migrationBuilder.DropForeignKey(
                name: "FK_Department_Person_ID",
                table: "Department");

            migrationBuilder.DropForeignKey(
                name: "FK_OfficeAssigned_Person_ID",
                table: "OfficeAssigned");

            migrationBuilder.RenameColumn(
                name: "ID",
                table: "OfficeAssigned",
                newName: "TutorID");

            migrationBuilder.RenameColumn(
                name: "ID",
                table: "Department",
                newName: "TutorID");

            migrationBuilder.RenameIndex(
                name: "IX_Department_ID",
                table: "Department",
                newName: "IX_Department_TutorID");

            migrationBuilder.RenameColumn(
                name: "ID",
                table: "CourseAssigned",
                newName: "TutorID");

            migrationBuilder.RenameIndex(
                name: "IX_CourseAssigned_ID",
                table: "CourseAssigned",
                newName: "IX_CourseAssigned_TutorID");

            migrationBuilder.RenameColumn(
                name: "ID",
                table: "Appointment",
                newName: "StudentID");

            migrationBuilder.RenameIndex(
                name: "IX_Appointment_ID",
                table: "Appointment",
                newName: "IX_Appointment_StudentID");

            //migrationBuilder.AlterColumn<int>(
            //    name: "ID",
            //    table: "Person",
            //    nullable: false,
            //    oldClrType: typeof(int))
            //    .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            migrationBuilder.AddForeignKey(
                name: "FK_Appointment_Person_StudentID",
                table: "Appointment",
                column: "StudentID",
                principalTable: "Person",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_CourseAssigned_Person_TutorID",
                table: "CourseAssigned",
                column: "TutorID",
                principalTable: "Person",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);

            //migrationBuilder.AddForeignKey(
            //    name: "FK_Department_Person_TutorID",
            //    table: "Department",
            //    column: "TutorID",
            //    principalTable: "Person",
            //    principalColumn: "ID",
            //    onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_OfficeAssigned_Person_TutorID",
                table: "OfficeAssigned",
                column: "TutorID",
                principalTable: "Person",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Appointment_Person_StudentID",
                table: "Appointment");

            migrationBuilder.DropForeignKey(
                name: "FK_CourseAssigned_Person_TutorID",
                table: "CourseAssigned");

            //migrationBuilder.DropForeignKey(
            //    name: "FK_Department_Person_TutorID",
            //    table: "Department");

            migrationBuilder.DropForeignKey(
                name: "FK_OfficeAssigned_Person_TutorID",
                table: "OfficeAssigned");

            migrationBuilder.RenameColumn(
                name: "TutorID",
                table: "OfficeAssigned",
                newName: "ID");

            migrationBuilder.RenameColumn(
                name: "TutorID",
                table: "Department",
                newName: "ID");

            migrationBuilder.RenameIndex(
                name: "IX_Department_TutorID",
                table: "Department",
                newName: "IX_Department_ID");

            migrationBuilder.RenameColumn(
                name: "TutorID",
                table: "CourseAssigned",
                newName: "ID");

            migrationBuilder.RenameIndex(
                name: "IX_CourseAssigned_TutorID",
                table: "CourseAssigned",
                newName: "IX_CourseAssigned_ID");

            migrationBuilder.RenameColumn(
                name: "StudentID",
                table: "Appointment",
                newName: "ID");

            migrationBuilder.RenameIndex(
                name: "IX_Appointment_StudentID",
                table: "Appointment",
                newName: "IX_Appointment_ID");

            migrationBuilder.AlterColumn<int>(
                name: "ID",
                table: "Person",
                nullable: false,
                oldClrType: typeof(int))
                .OldAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            migrationBuilder.AddForeignKey(
                name: "FK_Appointment_Person_ID",
                table: "Appointment",
                column: "ID",
                principalTable: "Person",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_CourseAssigned_Person_ID",
                table: "CourseAssigned",
                column: "ID",
                principalTable: "Person",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Department_Person_ID",
                table: "Department",
                column: "ID",
                principalTable: "Person",
                principalColumn: "ID",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_OfficeAssigned_Person_ID",
                table: "OfficeAssigned",
                column: "ID",
                principalTable: "Person",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
