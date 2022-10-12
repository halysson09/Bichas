using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Bichas.Migrations
{
    public partial class Initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Mesas",
                columns: table => new
                {
                    ID_MESA = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DS_MESA = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Mesas", x => x.ID_MESA);
                });

            migrationBuilder.CreateTable(
                name: "Reservas",
                columns: table => new
                {
                    ID_RESERVA = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    HORA_RESERVA = table.Column<DateTime>(type: "datetime2", nullable: false),
                    NOME_RESERVA = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ID_MESA = table.Column<int>(type: "int", nullable: false),
                    QTD_PESSOAS = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Reservas", x => x.ID_RESERVA);
                    table.ForeignKey(
                        name: "FK_Reservas_Mesas_ID_MESA",
                        column: x => x.ID_MESA,
                        principalTable: "Mesas",
                        principalColumn: "ID_MESA",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Reservas_ID_MESA",
                table: "Reservas",
                column: "ID_MESA");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Reservas");

            migrationBuilder.DropTable(
                name: "Mesas");
        }
    }
}
