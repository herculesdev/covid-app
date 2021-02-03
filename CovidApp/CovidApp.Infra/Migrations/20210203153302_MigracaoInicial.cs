using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace CovidApp.Infra.Migrations
{
    public partial class MigracaoInicial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "casos_covid",
                columns: table => new
                {
                    id = table.Column<string>(type: "TEXT", nullable: false),
                    nome_pais = table.Column<string>(type: "TEXT", nullable: true),
                    confirmados = table.Column<int>(type: "INTEGER", nullable: false),
                    mortes = table.Column<int>(type: "INTEGER", nullable: false),
                    recuperados = table.Column<int>(type: "INTEGER", nullable: false),
                    Ativos = table.Column<int>(type: "INTEGER", nullable: false),
                    data = table.Column<DateTime>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_casos_covid", x => x.id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "casos_covid");
        }
    }
}
