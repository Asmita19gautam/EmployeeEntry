using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EmpEntryFinal.Migrations
{
    public partial class visitorDb : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Appointment",
                table: "Visitors");

            migrationBuilder.AddColumn<int>(
                name: "EmployeeId",
                table: "Visitors",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Visitors_EmployeeId",
                table: "Visitors",
                column: "EmployeeId");

            migrationBuilder.AddForeignKey(
                name: "FK_Visitors_Employee_EmployeeId",
                table: "Visitors",
                column: "EmployeeId",
                principalTable: "Employee",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Visitors_Employee_EmployeeId",
                table: "Visitors");

            migrationBuilder.DropIndex(
                name: "IX_Visitors_EmployeeId",
                table: "Visitors");

            migrationBuilder.DropColumn(
                name: "EmployeeId",
                table: "Visitors");

            migrationBuilder.AddColumn<string>(
                name: "Appointment",
                table: "Visitors",
                type: "nvarchar(max)",
                nullable: true);
        }
    }
}
