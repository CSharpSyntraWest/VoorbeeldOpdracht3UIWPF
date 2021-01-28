using Microsoft.EntityFrameworkCore.Migrations;

namespace BierenWebAPI.Migrations
{
    public partial class CodeFirstInit : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Brouwer",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    BrNaam = table.Column<string>(unicode: false, maxLength: 50, nullable: true),
                    Adres = table.Column<string>(unicode: false, maxLength: 50, nullable: true),
                    PostCode = table.Column<short>(nullable: true),
                    Gemeente = table.Column<string>(unicode: false, maxLength: 50, nullable: true),
                    Omzet = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Brouwer", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Soort",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    SoortNaam = table.Column<string>(unicode: false, maxLength: 50, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Soort", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Bier",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Naam = table.Column<string>(unicode: false, maxLength: 100, nullable: true),
                    BrouwerId = table.Column<int>(nullable: true),
                    SoortId = table.Column<int>(nullable: true),
                    Alcohol = table.Column<double>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Bier", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Bieren_Brouwers",
                        column: x => x.BrouwerId,
                        principalTable: "Brouwer",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Bieren_Soorten",
                        column: x => x.SoortId,
                        principalTable: "Soort",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Bier_BrouwerId",
                table: "Bier",
                column: "BrouwerId");

            migrationBuilder.CreateIndex(
                name: "IX_Bier_SoortId",
                table: "Bier",
                column: "SoortId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Bier");

            migrationBuilder.DropTable(
                name: "Brouwer");

            migrationBuilder.DropTable(
                name: "Soort");
        }
    }
}
