using Microsoft.EntityFrameworkCore.Migrations;

namespace Facec.Repositorio.Migrations
{
    public partial class MigrationUnificada_1_1_0 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "TP_SEXO",
                table: "CLIENTE",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "TP_SEXO",
                table: "CLIENTE");
        }
    }
}
