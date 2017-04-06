using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.Migrations;

namespace TutorApp.Migrations
{
    public partial class newupdate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            //migrationBuilder.DropForeignKey(
            //    name: "FK_Appointment_Person_TutorID",
            //    table: "Appointment");

            migrationBuilder.AlterColumn<int>(
                name: "TutorID",
                table: "Appointment",
                nullable: false,
                oldClrType: typeof(int),
                oldNullable: true);

            //migrationBuilder.AddForeignKey(
            //    name: "FK_Appointment_Person_TutorID",
            //    table: "Appointment",
            //    column: "TutorID",
            //    principalTable: "Person",
            //    principalColumn: "ID",
            //    onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            //migrationBuilder.DropForeignKey(
            //    name: "FK_Appointment_Person_TutorID",
            //    table: "Appointment");

            migrationBuilder.AlterColumn<int>(
                name: "TutorID",
                table: "Appointment",
                nullable: true,
                oldClrType: typeof(int));

            //migrationBuilder.AddForeignKey(
            //    name: "FK_Appointment_Person_TutorID",
            //    table: "Appointment",
            //    column: "TutorID",
            //    principalTable: "Person",
            //    principalColumn: "ID",
            //    onDelete: ReferentialAction.Restrict);
        }
    }
}
