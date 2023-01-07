using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Dog_Grooming_Salon.Migrations
{
    public partial class BreedD : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "BreedID",
                table: "Dog",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Dog_BreedID",
                table: "Dog",
                column: "BreedID");

            migrationBuilder.AddForeignKey(
                name: "FK_Dog_Breed_BreedID",
                table: "Dog",
                column: "BreedID",
                principalTable: "Breed",
                principalColumn: "ID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Dog_Breed_BreedID",
                table: "Dog");

            migrationBuilder.DropIndex(
                name: "IX_Dog_BreedID",
                table: "Dog");

            migrationBuilder.DropColumn(
                name: "BreedID",
                table: "Dog");
        }
    }
}
