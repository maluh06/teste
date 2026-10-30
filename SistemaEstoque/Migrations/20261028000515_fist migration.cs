using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SistemaEstoque.Migrations
{
    /// <inheritdoc />
    public partial class fistmigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Fornecedores",
                columns: table => new
                {
                    CNPJ = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Nome = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Telefone = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Fornecedores", x => x.CNPJ);
                });

            migrationBuilder.CreateTable(
                name: "Produtos",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    nome = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    precoCusto = table.Column<double>(type: "float", nullable: false),
                    quantidade = table.Column<int>(type: "int", nullable: false),
                    fornecedorCNPJ = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    categoria = table.Column<int>(type: "int", nullable: false),
                    precoVenda = table.Column<double>(type: "float", nullable: false),
                    estoqueMinimo = table.Column<int>(type: "int", nullable: false),
                    primeiraEntrada = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ultimaEntrada = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Produtos", x => x.id);
                    table.ForeignKey(
                        name: "FK_Produtos_Fornecedores_fornecedorCNPJ",
                        column: x => x.fornecedorCNPJ,
                        principalTable: "Fornecedores",
                        principalColumn: "CNPJ",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Produtos_fornecedorCNPJ",
                table: "Produtos",
                column: "fornecedorCNPJ");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Produtos");

            migrationBuilder.DropTable(
                name: "Fornecedores");
        }
    }
}
