using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WebCegMVC1.Data.Migrations
{
    public partial class modellMunkatars : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "modellMunkatars",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    nev = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    varos = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    beosztas = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    nyelvtudas = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_modellMunkatars", x => x.id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "modellMunkatars");
        }
    }
}
