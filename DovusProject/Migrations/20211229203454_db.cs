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
                name: "Maclar",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Dovuscu1 = table.Column<int>(type: "int", nullable: false),
                    Dovuscu2 = table.Column<int>(type: "int", nullable: false),
                    VurmaSirasi = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Maclar", x => x.Id);
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
                    table.PrimaryKey("PK_MacLoglari", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "GecmisMaclar",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Dovuscu1Id = table.Column<int>(type: "int", nullable: true),
                    Dovuscu2Id = table.Column<int>(type: "int", nullable: true),
                    KazananId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GecmisMaclar", x => x.Id);
                    table.ForeignKey(
                        name: "FK_GecmisMaclar_DovuscuOzellikleri_Dovuscu1Id",
                        column: x => x.Dovuscu1Id,
                        principalTable: "DovuscuOzellikleri",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_GecmisMaclar_DovuscuOzellikleri_Dovuscu2Id",
                        column: x => x.Dovuscu2Id,
                        principalTable: "DovuscuOzellikleri",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.InsertData(
                table: "DovuscuOzellikleri",
                columns: new[] { "Id", "Ad", "CanDegeri", "DuzVurusHasari", "Yetenek1", "Yetenek1Hasari", "Yetenek2", "Yetenek2Hasari", "ZırhDegeri" },
                values: new object[] { 1, "Armor King", 100, 10, "Aparkat", 25, "Döner Tekme", 35, 100 });

            migrationBuilder.CreateIndex(
                name: "IX_GecmisMaclar_Dovuscu1Id",
                table: "GecmisMaclar",
                column: "Dovuscu1Id");

            migrationBuilder.CreateIndex(
                name: "IX_GecmisMaclar_Dovuscu2Id",
                table: "GecmisMaclar",
                column: "Dovuscu2Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "GecmisMaclar");

            migrationBuilder.DropTable(
                name: "Maclar");

            migrationBuilder.DropTable(
                name: "MacLoglari");

            migrationBuilder.DropTable(
                name: "DovuscuOzellikleri");
        }
    }
}
