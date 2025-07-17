using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CRUD_4t.Migrations
{
    /// <inheritdoc />
    public partial class NovaMigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Fazendas",
                columns: table => new
                {
                    Cod_fazenda = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Nome = table.Column<string>(type: "TEXT", nullable: false),
                    Area_HA = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Fazendas", x => x.Cod_fazenda);
                });

            migrationBuilder.CreateTable(
                name: "Operacoes",
                columns: table => new
                {
                    Cod_Operacao = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Descricao = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Operacoes", x => x.Cod_Operacao);
                });

            migrationBuilder.CreateTable(
                name: "Produtores",
                columns: table => new
                {
                    Cod_Produtor = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Nome = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Produtores", x => x.Cod_Produtor);
                });

            migrationBuilder.CreateTable(
                name: "Movimentacoes",
                columns: table => new
                {
                    Cod_movimentacao = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Cod_Fazenda = table.Column<int>(type: "INTEGER", nullable: false),
                    Cod_Produtor = table.Column<int>(type: "INTEGER", nullable: false),
                    Cod_Operacao = table.Column<int>(type: "INTEGER", nullable: false),
                    data = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Movimentacoes", x => x.Cod_movimentacao);
                    table.ForeignKey(
                        name: "FK_Movimentacoes_Fazendas_Cod_Fazenda",
                        column: x => x.Cod_Fazenda,
                        principalTable: "Fazendas",
                        principalColumn: "Cod_fazenda",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Movimentacoes_Operacoes_Cod_Operacao",
                        column: x => x.Cod_Operacao,
                        principalTable: "Operacoes",
                        principalColumn: "Cod_Operacao",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Movimentacoes_Produtores_Cod_Produtor",
                        column: x => x.Cod_Produtor,
                        principalTable: "Produtores",
                        principalColumn: "Cod_Produtor",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Movimentacoes_Cod_Fazenda",
                table: "Movimentacoes",
                column: "Cod_Fazenda");

            migrationBuilder.CreateIndex(
                name: "IX_Movimentacoes_Cod_Operacao",
                table: "Movimentacoes",
                column: "Cod_Operacao");

            migrationBuilder.CreateIndex(
                name: "IX_Movimentacoes_Cod_Produtor",
                table: "Movimentacoes",
                column: "Cod_Produtor");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Movimentacoes");

            migrationBuilder.DropTable(
                name: "Fazendas");

            migrationBuilder.DropTable(
                name: "Operacoes");

            migrationBuilder.DropTable(
                name: "Produtores");
        }
    }
}
