using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.Migrations;

namespace TutorApp.Migrations
{
    public partial class Appointment : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "TutorID",
                table: "Appointment",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Appointment_TutorID",
                table: "Appointment",
                column: "TutorID");

            //migrationBuilder.AddForeignKey(
            //    name: "FK_Appointment_Person_TutorID",
            //    table: "Appointment",
            //    column: "TutorID",
            //    principalTable: "Person",
            //    principalColumn: "ID",
            //    onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            //migrationBuilder.DropForeignKey(
            //    name: "FK_Appointment_Person_TutorID",
            //    table: "Appointment");
            //migrationBuilder.DropForeignKey(
            //    name: "FK_Department_Person_TutorID",
            //    table: "Department");

            migrationBuilder.DropIndex(
                name: "IX_Appointment_TutorID",
                table: "Appointment");

            migrationBuilder.DropColumn(
                name: "TutorID",
                table: "Appointment");
        }
    }
}
