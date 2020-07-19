using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace estagio_brg.Entities.Migrations
{
    public partial class GenerateDatabase : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Colaboradores",
                columns: table => new
                {
                    IdColaborador = table.Column<Guid>(nullable: false),
                    Cargo = table.Column<string>(maxLength: 50, nullable: false),
                    Departamento = table.Column<string>(maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Colaboradores", x => x.IdColaborador);
                });

            migrationBuilder.CreateTable(
                name: "Habilidades",
                columns: table => new
                {
                    IdHabilidade = table.Column<Guid>(nullable: false),
                    Nome = table.Column<string>(maxLength: 50, nullable: false),
                    Tipo = table.Column<string>(maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Habilidades", x => x.IdHabilidade);
                });

            migrationBuilder.CreateTable(
                name: "Trilhas",
                columns: table => new
                {
                    IdTrilha = table.Column<Guid>(nullable: false),
                    Prazo = table.Column<DateTime>(nullable: false),
                    IdColaborador = table.Column<Guid>(nullable: false),
                    Idhabilidade = table.Column<Guid>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Trilhas", x => x.IdTrilha);
                    table.ForeignKey(
                        name: "FK_Trilhas_Colaboradores_IdColaborador",
                        column: x => x.IdColaborador,
                        principalTable: "Colaboradores",
                        principalColumn: "IdColaborador",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Trilhas_Habilidades_Idhabilidade",
                        column: x => x.Idhabilidade,
                        principalTable: "Habilidades",
                        principalColumn: "IdHabilidade",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Trilhas_IdColaborador",
                table: "Trilhas",
                column: "IdColaborador");

            migrationBuilder.CreateIndex(
                name: "IX_Trilhas_Idhabilidade",
                table: "Trilhas",
                column: "Idhabilidade");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Trilhas");

            migrationBuilder.DropTable(
                name: "Colaboradores");

            migrationBuilder.DropTable(
                name: "Habilidades");
        }
    }
}
