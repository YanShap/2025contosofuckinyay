using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace _2025contosofuckinyay.Migrations
{
    /// <inheritdoc />
    public partial class fc2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Admin",
                table: "FieldCampuses",
                newName: "ShortName");

            migrationBuilder.AddColumn<string>(
                name: "Address",
                table: "FieldCampuses",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Budget",
                table: "FieldCampuses",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Description",
                table: "FieldCampuses",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<int>(
                name: "InstructorID",
                table: "FieldCampuses",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "OpenTime",
                table: "FieldCampuses",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<DateTime>(
                name: "OpeningDate",
                table: "FieldCampuses",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<byte>(
                name: "RowVersion",
                table: "FieldCampuses",
                type: "tinyint",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "FieldCampusId",
                table: "Course",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_FieldCampuses_InstructorID",
                table: "FieldCampuses",
                column: "InstructorID");

            migrationBuilder.CreateIndex(
                name: "IX_Course_FieldCampusId",
                table: "Course",
                column: "FieldCampusId");

            migrationBuilder.AddForeignKey(
                name: "FK_Course_FieldCampuses_FieldCampusId",
                table: "Course",
                column: "FieldCampusId",
                principalTable: "FieldCampuses",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_FieldCampuses_Instructors_InstructorID",
                table: "FieldCampuses",
                column: "InstructorID",
                principalTable: "Instructors",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Course_FieldCampuses_FieldCampusId",
                table: "Course");

            migrationBuilder.DropForeignKey(
                name: "FK_FieldCampuses_Instructors_InstructorID",
                table: "FieldCampuses");

            migrationBuilder.DropIndex(
                name: "IX_FieldCampuses_InstructorID",
                table: "FieldCampuses");

            migrationBuilder.DropIndex(
                name: "IX_Course_FieldCampusId",
                table: "Course");

            migrationBuilder.DropColumn(
                name: "Address",
                table: "FieldCampuses");

            migrationBuilder.DropColumn(
                name: "Budget",
                table: "FieldCampuses");

            migrationBuilder.DropColumn(
                name: "Description",
                table: "FieldCampuses");

            migrationBuilder.DropColumn(
                name: "InstructorID",
                table: "FieldCampuses");

            migrationBuilder.DropColumn(
                name: "OpenTime",
                table: "FieldCampuses");

            migrationBuilder.DropColumn(
                name: "OpeningDate",
                table: "FieldCampuses");

            migrationBuilder.DropColumn(
                name: "RowVersion",
                table: "FieldCampuses");

            migrationBuilder.DropColumn(
                name: "FieldCampusId",
                table: "Course");

            migrationBuilder.RenameColumn(
                name: "ShortName",
                table: "FieldCampuses",
                newName: "Admin");
        }
    }
}
