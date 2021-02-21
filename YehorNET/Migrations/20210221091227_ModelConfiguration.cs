using Microsoft.EntityFrameworkCore.Migrations;

namespace YehorNET.Migrations
{
    public partial class ModelConfiguration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_DoctorsComments_Doctors_DoctorId",
                table: "DoctorsComments");

            migrationBuilder.RenameColumn(
                name: "Comments",
                table: "DoctorsComments",
                newName: "Text");

            migrationBuilder.AddForeignKey(
                name: "FK_DoctorsComments_Doctors_DoctorId",
                table: "DoctorsComments",
                column: "DoctorId",
                principalTable: "Doctors",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_DoctorsComments_Doctors_DoctorId",
                table: "DoctorsComments");

            migrationBuilder.RenameColumn(
                name: "Text",
                table: "DoctorsComments",
                newName: "Comments");

            migrationBuilder.AddForeignKey(
                name: "FK_DoctorsComments_Doctors_DoctorId",
                table: "DoctorsComments",
                column: "DoctorId",
                principalTable: "Doctors",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
