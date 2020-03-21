using Microsoft.EntityFrameworkCore.Migrations;

namespace AerolineaExpress.Migrations
{
    public partial class v20 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "AvionId",
                table: "planificados",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "Clientes",
                columns: table => new
                {
                    ClientesId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nombre = table.Column<string>(nullable: true),
                    Apellidos = table.Column<string>(nullable: true),
                    Destino = table.Column<string>(nullable: true),
                    MetodoDePago = table.Column<string>(nullable: true),
                    NumeroDeCuenta = table.Column<string>(nullable: true),
                    PlanificadosVuelosId = table.Column<int>(nullable: true),
                    confimarVuelo = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Clientes", x => x.ClientesId);
                    table.ForeignKey(
                        name: "FK_Clientes_planificados_PlanificadosVuelosId",
                        column: x => x.PlanificadosVuelosId,
                        principalTable: "planificados",
                        principalColumn: "VuelosId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_planificados_AvionId",
                table: "planificados",
                column: "AvionId");

            migrationBuilder.CreateIndex(
                name: "IX_Clientes_PlanificadosVuelosId",
                table: "Clientes",
                column: "PlanificadosVuelosId");

            migrationBuilder.AddForeignKey(
                name: "FK_planificados_avions_AvionId",
                table: "planificados",
                column: "AvionId",
                principalTable: "avions",
                principalColumn: "AvionId",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_planificados_avions_AvionId",
                table: "planificados");

            migrationBuilder.DropTable(
                name: "Clientes");

            migrationBuilder.DropIndex(
                name: "IX_planificados_AvionId",
                table: "planificados");

            migrationBuilder.DropColumn(
                name: "AvionId",
                table: "planificados");
        }
    }
}
