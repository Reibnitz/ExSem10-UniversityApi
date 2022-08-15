using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace University.Migrations
{
    public partial class CreateTableRegistration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Matricula",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IdTurma = table.Column<int>(type: "int", nullable: false),
                    IdAluno = table.Column<int>(type: "int", nullable: false),
                    RegistrationDate = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Matricula", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Matricula_Aluno_IdAluno",
                        column: x => x.IdAluno,
                        principalTable: "Aluno",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Matricula_Turma_IdTurma",
                        column: x => x.IdTurma,
                        principalTable: "Turma",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Matricula_IdAluno",
                table: "Matricula",
                column: "IdAluno");

            migrationBuilder.CreateIndex(
                name: "IX_Matricula_IdTurma",
                table: "Matricula",
                column: "IdTurma");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Matricula");
        }
    }
}
