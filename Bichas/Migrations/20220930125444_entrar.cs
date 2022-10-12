using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Bichas.Migrations
{
    public partial class entrar : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "ENTROU",
                table: "Reservas",
                type: "bit",
                nullable: false,
                defaultValue: false);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ENTROU",
                table: "Reservas");
        }
    }
}
