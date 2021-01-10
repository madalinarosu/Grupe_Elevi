using Microsoft.EntityFrameworkCore.Migrations;

namespace Grupe_Elevi.Migrations
{
    public partial class ClasaElevi : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "CNP",
                table: "Elev",
                type: "nvarchar(16)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AddColumn<int>(
                name: "ScoalaID",
                table: "Elev",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "Clasa",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NumeClasa = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Clasa", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "Scoala",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DenumireScoala = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Scoala", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "ClasaElevi",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ElevID = table.Column<int>(nullable: false),
                    ClasaID = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ClasaElevi", x => x.ID);
                    table.ForeignKey(
                        name: "FK_ClasaElevi_Clasa_ClasaID",
                        column: x => x.ClasaID,
                        principalTable: "Clasa",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ClasaElevi_Elev_ElevID",
                        column: x => x.ElevID,
                        principalTable: "Elev",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Elev_ScoalaID",
                table: "Elev",
                column: "ScoalaID");

            migrationBuilder.CreateIndex(
                name: "IX_ClasaElevi_ClasaID",
                table: "ClasaElevi",
                column: "ClasaID");

            migrationBuilder.CreateIndex(
                name: "IX_ClasaElevi_ElevID",
                table: "ClasaElevi",
                column: "ElevID");

            migrationBuilder.AddForeignKey(
                name: "FK_Elev_Scoala_ScoalaID",
                table: "Elev",
                column: "ScoalaID",
                principalTable: "Scoala",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Elev_Scoala_ScoalaID",
                table: "Elev");

            migrationBuilder.DropTable(
                name: "ClasaElevi");

            migrationBuilder.DropTable(
                name: "Scoala");

            migrationBuilder.DropTable(
                name: "Clasa");

            migrationBuilder.DropIndex(
                name: "IX_Elev_ScoalaID",
                table: "Elev");

            migrationBuilder.DropColumn(
                name: "ScoalaID",
                table: "Elev");

            migrationBuilder.AlterColumn<string>(
                name: "CNP",
                table: "Elev",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(16)",
                oldNullable: true);
        }
    }
}
