using Microsoft.EntityFrameworkCore.Migrations;

namespace ISM6225_Assignment4.Migrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "FishingAreas",
                columns: table => new
                {
                    id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    WaterBody = table.Column<string>(nullable: true),
                    Town = table.Column<string>(nullable: true),
                    County = table.Column<string>(nullable: true),
                    Owner = table.Column<string>(nullable: true),
                    Manager = table.Column<string>(nullable: true),
                    AccessType = table.Column<string>(nullable: true),
                    BoatSize = table.Column<string>(nullable: true),
                    RampType = table.Column<string>(nullable: true),
                    UniversalAcess = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FishingAreas", x => x.id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "FishingAreas");
        }
    }
}
