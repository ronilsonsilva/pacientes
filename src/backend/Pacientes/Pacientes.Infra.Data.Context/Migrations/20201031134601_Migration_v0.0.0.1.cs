using System;
using Microsoft.EntityFrameworkCore.Migrations;
using MySql.Data.EntityFrameworkCore.Metadata;

namespace Pacientes.Infra.Data.Context.Migrations
{
    public partial class Migration_v0001 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Paciente",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("MySQL:ValueGenerationStrategy", MySQLValueGenerationStrategy.IdentityColumn),
                    DataCadastro = table.Column<DateTime>(nullable: false, defaultValue: new DateTime(2020, 10, 31, 10, 46, 0, 736, DateTimeKind.Local).AddTicks(6329)),
                    Nome = table.Column<string>(maxLength: 256, nullable: false),
                    CPF = table.Column<long>(nullable: false),
                    RG = table.Column<long>(nullable: false),
                    Cns = table.Column<long>(nullable: false),
                    DataNascimento = table.Column<DateTime>(nullable: false),
                    Sexo = table.Column<int>(nullable: false),
                    NomeMae = table.Column<string>(maxLength: 256, nullable: true),
                    Endereco = table.Column<string>(maxLength: 512, nullable: false),
                    Bairro = table.Column<string>(maxLength: 256, nullable: false),
                    Cep = table.Column<int>(nullable: false),
                    Estado = table.Column<string>(maxLength: 2, nullable: false),
                    Cidade = table.Column<string>(maxLength: 256, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Paciente", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Telefone",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("MySQL:ValueGenerationStrategy", MySQLValueGenerationStrategy.IdentityColumn),
                    DataCadastro = table.Column<DateTime>(nullable: false, defaultValue: new DateTime(2020, 10, 31, 10, 46, 0, 682, DateTimeKind.Local).AddTicks(641)),
                    Tipo = table.Column<int>(nullable: false),
                    DDD = table.Column<int>(nullable: false),
                    Numero = table.Column<long>(nullable: false),
                    PacienteId = table.Column<long>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Telefone", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Telefone_Paciente_PacienteId",
                        column: x => x.PacienteId,
                        principalTable: "Paciente",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Telefone_PacienteId",
                table: "Telefone",
                column: "PacienteId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Telefone");

            migrationBuilder.DropTable(
                name: "Paciente");
        }
    }
}
