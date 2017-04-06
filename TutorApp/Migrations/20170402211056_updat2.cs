using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.Migrations;

namespace TutorApp.Migrations
{
    public partial class updat2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
        //migrationBuilder.AddForeignKey(
        //name: "FK_Department_Person_TutorID",
        //table: "Department",
        //column: "TutorID",
        //principalTable: "Person",
        //principalColumn: "ID",
        //onDelete: ReferentialAction.Cascade);

        migrationBuilder.AddForeignKey(
        name: "FK_OfficeAssigned_Person_TutorID",
        table: "OfficeAssigned",
        column: "TutorID",
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
        }

    protected override void Down(MigrationBuilder migrationBuilder)
        {

        }
    }
}
