using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Dog_Grooming_Salon.Migrations
{
    public partial class OwnerEmail : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Email",
                table: "Owner",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Email",
                table: "Owner");
        }
    }
}
