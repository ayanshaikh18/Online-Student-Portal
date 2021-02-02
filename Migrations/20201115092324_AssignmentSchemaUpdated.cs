using Microsoft.EntityFrameworkCore.Migrations;

namespace StudentPortal.Migrations
{
    public partial class AssignmentSchemaUpdated : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "FacultyId",
                table: "Assignments",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Assignments_FacultyId",
                table: "Assignments",
                column: "FacultyId");

            migrationBuilder.AddForeignKey(
                name: "FK_Assignments_AspNetUsers_FacultyId",
                table: "Assignments",
                column: "FacultyId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Assignments_AspNetUsers_FacultyId",
                table: "Assignments");

            migrationBuilder.DropIndex(
                name: "IX_Assignments_FacultyId",
                table: "Assignments");

            migrationBuilder.DropColumn(
                name: "FacultyId",
                table: "Assignments");
        }
    }
}
