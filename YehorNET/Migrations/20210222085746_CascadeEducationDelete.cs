using Microsoft.EntityFrameworkCore.Migrations;

namespace YehorNET.Migrations
{
    public partial class CascadeEducationDelete : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_DoctorsEducations_Doctors_DoctorId",
                table: "DoctorsEducations");

            migrationBuilder.AddForeignKey(
                name: "FK_DoctorsEducations_Doctors_DoctorId",
                table: "DoctorsEducations",
                column: "DoctorId",
                principalTable: "Doctors",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_DoctorsEducations_Doctors_DoctorId",
                table: "DoctorsEducations");

            migrationBuilder.AddForeignKey(
                name: "FK_DoctorsEducations_Doctors_DoctorId",
                table: "DoctorsEducations",
                column: "DoctorId",
                principalTable: "Doctors",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
