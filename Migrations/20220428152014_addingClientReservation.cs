using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace barber_shops.Migrations
{
    public partial class addingClientReservation : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ClientReservations",
                columns: table => new
                {
                    Id = table.Column<string>(type: "TEXT", nullable: false),
                    ClientId = table.Column<string>(type: "TEXT", nullable: false),
                    BarberId = table.Column<string>(type: "TEXT", nullable: false),
                    StartTime = table.Column<string>(type: "TEXT", nullable: false),
                    EndTime = table.Column<string>(type: "TEXT", nullable: false),
                    Haircut = table.Column<bool>(type: "INTEGER", nullable: false),
                    BearTrim = table.Column<bool>(type: "INTEGER", nullable: false),
                    SkinCare = table.Column<bool>(type: "INTEGER", nullable: false),
                    Wax = table.Column<bool>(type: "INTEGER", nullable: false),
                    QuickShower = table.Column<bool>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ClientReservations", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ClientReservations");
        }
    }
}
