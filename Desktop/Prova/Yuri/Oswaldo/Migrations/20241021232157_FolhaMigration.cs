using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Oswaldo.Migrations
{
    /// <inheritdoc />
    public partial class FolhaMigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Folha",
                columns: table => new
                {
                    folhaId = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    valor = table.Column<double>(type: "REAL", nullable: false),
                    quantidade = table.Column<int>(type: "INTEGER", nullable: false),
                    mes = table.Column<int>(type: "INTEGER", nullable: false),
                    ano = table.Column<int>(type: "INTEGER", nullable: false),
                    salarioBruto = table.Column<double>(type: "REAL", nullable: false),
                    salarioLiquido = table.Column<double>(type: "REAL", nullable: false),
                    impostoIrrf = table.Column<double>(type: "REAL", nullable: false),
                    impostoInss = table.Column<double>(type: "REAL", nullable: false),
                    impossoFgts = table.Column<double>(type: "REAL", nullable: false),
                    funcionarioId = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Folha", x => x.folhaId);
                    table.ForeignKey(
                        name: "FK_Folha_Funcionario_funcionarioId",
                        column: x => x.funcionarioId,
                        principalTable: "Funcionario",
                        principalColumn: "funcionarioId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Folha_funcionarioId",
                table: "Folha",
                column: "funcionarioId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Folha");
        }
    }
}
