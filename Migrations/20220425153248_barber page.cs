using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace barber_shops.Migrations
{
    public partial class barberpage : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Accomplishments",
                table: "Barbers",
                type: "TEXT",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Description",
                table: "Barbers",
                type: "TEXT",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Experience",
                table: "Barbers",
                type: "TEXT",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Products",
                table: "Barbers",
                type: "TEXT",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Skills",
                table: "Barbers",
                type: "TEXT",
                nullable: false,
                defaultValue: "");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Accomplishments",
                table: "Barbers");

            migrationBuilder.DropColumn(
                name: "Description",
                table: "Barbers");

            migrationBuilder.DropColumn(
                name: "Experience",
                table: "Barbers");

            migrationBuilder.DropColumn(
                name: "Products",
                table: "Barbers");

            migrationBuilder.DropColumn(
                name: "Skills",
                table: "Barbers");
        }
    }
}
