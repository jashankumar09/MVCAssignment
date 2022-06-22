using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SMSystem.Migrations
{
    public partial class firstmigration03 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "StudentId",
                table: "Students",
                newName: "Id");

            migrationBuilder.RenameColumn(
                name: "CourseId",
                table: "Courses",
                newName: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Id",
                table: "Students",
                newName: "StudentId");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "Courses",
                newName: "CourseId");
        }
    }
}
