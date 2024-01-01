using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EmpEntryFinal.Migrations
{
    public partial class AddedTime : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "OfficeTime",
                table: "Employee",
                newName: "StartTime");

            migrationBuilder.AddColumn<string>(
                name: "EndTime",
                table: "Employee",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "EndTime",
                table: "Employee");

            migrationBuilder.RenameColumn(
                name: "StartTime",
                table: "Employee",
                newName: "OfficeTime");
        }
    }
}
