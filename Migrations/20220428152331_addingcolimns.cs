using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace barber_shops.Migrations
{
    public partial class addingcolimns : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "ClientId",
                table: "ClientReservations",
                newName: "ClientEmail");

            migrationBuilder.RenameColumn(
                name: "BarberId",
                table: "ClientReservations",
                newName: "BarberEmail");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "ClientEmail",
                table: "ClientReservations",
                newName: "ClientId");

            migrationBuilder.RenameColumn(
                name: "BarberEmail",
                table: "ClientReservations",
                newName: "BarberId");
        }
    }
}
