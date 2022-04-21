using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace barber_shops.Migrations
{
    public partial class addedautogenerateid : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "IMG",
                table: "Barbers",
                type: "TEXT",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Location",
                table: "Barbers",
                type: "TEXT",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<int>(
                name: "Rating",
                table: "Barbers",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "averagePrice",
                table: "Barbers",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IMG",
                table: "Barbers");

            migrationBuilder.DropColumn(
                name: "Location",
                table: "Barbers");

            migrationBuilder.DropColumn(
                name: "Rating",
                table: "Barbers");

            migrationBuilder.DropColumn(
                name: "averagePrice",
                table: "Barbers");
        }
    }
}
