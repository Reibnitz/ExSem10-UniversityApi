using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace University.Migrations
{
    public partial class CreateTableTeam : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Turma",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IdInstrutor = table.Column<int>(type: "int", nullable: false),
                    IdCurso = table.Column<int>(type: "int", nullable: false),
                    DataInicio = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DataFinal = table.Column<DateTime>(type: "datetime2", nullable: true),
                    CargaHoraria = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Turma", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Turma_Disciplina_IdCurso",
                        column: x => x.IdCurso,
                        principalTable: "Disciplina",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Turma_Instrutor_IdInstrutor",
                        column: x => x.IdInstrutor,
                        principalTable: "Instrutor",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Turma_IdCurso",
                table: "Turma",
                column: "IdCurso");

            migrationBuilder.CreateIndex(
                name: "IX_Turma_IdInstrutor",
                table: "Turma",
                column: "IdInstrutor");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Turma");
        }
    }
}
