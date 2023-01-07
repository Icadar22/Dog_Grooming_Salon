using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Dog_Grooming_Salon.Migrations
{
    public partial class Owner : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "OwnerName",
                table: "Owner",
                newName: "LastName");

            migrationBuilder.AddColumn<string>(
                name: "FirstName",
                table: "Owner",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "FirstName",
                table: "Owner");

            migrationBuilder.RenameColumn(
                name: "LastName",
                table: "Owner",
                newName: "OwnerName");
        }
    }
}
