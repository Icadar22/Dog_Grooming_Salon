using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Dog_Grooming_Salon.Migrations
{
    public partial class DogService : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "ServiceID",
                table: "Dog",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Dog_ServiceID",
                table: "Dog",
                column: "ServiceID");

            migrationBuilder.AddForeignKey(
                name: "FK_Dog_Service_ServiceID",
                table: "Dog",
                column: "ServiceID",
                principalTable: "Service",
                principalColumn: "ID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Dog_Service_ServiceID",
                table: "Dog");

            migrationBuilder.DropIndex(
                name: "IX_Dog_ServiceID",
                table: "Dog");

            migrationBuilder.DropColumn(
                name: "ServiceID",
                table: "Dog");
        }
    }
}
