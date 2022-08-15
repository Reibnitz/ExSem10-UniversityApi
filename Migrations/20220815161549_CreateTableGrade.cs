using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace University.Migrations
{
    public partial class CreateTableGrade : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Nota",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nota = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    IdMatricula = table.Column<int>(type: "int", nullable: false),
                    IdNotaPeriodo = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Nota", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Nota_Matricula_IdMatricula",
                        column: x => x.IdMatricula,
                        principalTable: "Matricula",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Nota_NotaPeriodo_IdNotaPeriodo",
                        column: x => x.IdNotaPeriodo,
                        principalTable: "NotaPeriodo",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Nota_IdMatricula",
                table: "Nota",
                column: "IdMatricula");

            migrationBuilder.CreateIndex(
                name: "IX_Nota_IdNotaPeriodo",
                table: "Nota",
                column: "IdNotaPeriodo");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Nota");
        }
    }
}
