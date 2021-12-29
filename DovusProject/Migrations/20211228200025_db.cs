using Microsoft.EntityFrameworkCore.Migrations;

namespace DovusProject.Migrations
{
    public partial class db : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "DovuscuOzellikleri",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Ad = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CanDegeri = table.Column<int>(type: "int", nullable: false),
                    ZırhDegeri = table.Column<int>(type: "int", nullable: false),
                    DuzVurusHasari = table.Column<int>(type: "int", nullable: false),
                    Yetenek1 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Yetenek1Hasari = table.Column<int>(type: "int", nullable: false),
                    Yetenek2 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Yetenek2Hasari = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DovuscuOzellikleri", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "MacLoglari",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Olaylar = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SavasLoglari", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "GecmisMaclar",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Oyuncu1Id = table.Column<int>(type: "int", nullable: true),
                    Oyuncu2Id = table.Column<int>(type: "int", nullable: true),
                    KazananId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GecmisMaclar", x => x.Id);
                    table.ForeignKey(
                        name: "FK_GecmisMaclar_DovuscuOzellikleri_Oyuncu1Id",
                        column: x => x.Oyuncu1Id,
                        principalTable: "DovuscuOzellikleri",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_GecmisMaclar_DovuscuOzellikleri_Oyuncu2Id",
                        column: x => x.Oyuncu2Id,
                        principalTable: "DovuscuOzellikleri",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.InsertData(
                table: "DovuscuOzellikleri",
                columns: new[] { "Id", "Ad", "CanDegeri", "DuzVurusHasari", "Yetenek1", "Yetenek1Hasari", "Yetenek2", "Yetenek2Hasari", "ZırhDegeri" },
                values: new object[] { 1, "Armor King", 100, 10, "Aparkat", 25, "Döner Tekme", 35, 100 });

            migrationBuilder.CreateIndex(
                name: "IX_GecmisMaclar_Oyuncu1Id",
                table: "GecmisMaclar",
                column: "Oyuncu1Id");

            migrationBuilder.CreateIndex(
                name: "IX_GecmisMaclar_Oyuncu2Id",
                table: "GecmisMaclar",
                column: "Oyuncu2Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "GecmisMaclar");

            migrationBuilder.DropTable(
                name: "MacLoglari");

            migrationBuilder.DropTable(
                name: "DovuscuOzellikleri");
        }
    }
}
