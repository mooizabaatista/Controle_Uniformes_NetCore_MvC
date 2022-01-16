using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Requisicao_RSS.Infra.Data.Migrations
{
    public partial class m0 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Fornecedores",
                columns: table => new
                {
                    FornecedorId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nome = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Telefone = table.Column<string>(type: "nvarchar(14)", maxLength: 14, nullable: false),
                    CNPJ = table.Column<string>(type: "nvarchar(18)", maxLength: 18, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Fornecedores", x => x.FornecedorId);
                });

            migrationBuilder.CreateTable(
                name: "Funcionarios",
                columns: table => new
                {
                    FuncionarioId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Registro = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Nome = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Funcao = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: false),
                    Turno = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: false),
                    BaseCamisa = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    BaseCalca = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Funcionarios", x => x.FuncionarioId);
                });

            migrationBuilder.CreateTable(
                name: "EntregaMateriais",
                columns: table => new
                {
                    EntregaMaterialId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Data = table.Column<DateTime>(type: "datetime2", nullable: true),
                    NomeFornecedor = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Tipo = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: false),
                    QuantidadeCamisas = table.Column<int>(type: "int", nullable: false),
                    QuantidadeCalcas = table.Column<int>(type: "int", nullable: false),
                    QuantidadeLuvas = table.Column<int>(type: "int", nullable: false),
                    Divergencia = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Observacoes = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    FornecedorId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EntregaMateriais", x => x.EntregaMaterialId);
                    table.ForeignKey(
                        name: "FK_EntregaMateriais_Fornecedores_FornecedorId",
                        column: x => x.FornecedorId,
                        principalTable: "Fornecedores",
                        principalColumn: "FornecedorId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "RetiradaMateriais",
                columns: table => new
                {
                    RetiradaMaterialId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Data = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Tipo = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: false),
                    NomeFornecedor = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    QuantidadeCamisas = table.Column<int>(type: "int", nullable: false),
                    QuantidadeCalcas = table.Column<int>(type: "int", nullable: false),
                    QuantidadeLuvas = table.Column<int>(type: "int", nullable: false),
                    FornecedorId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RetiradaMateriais", x => x.RetiradaMaterialId);
                    table.ForeignKey(
                        name: "FK_RetiradaMateriais_Fornecedores_FornecedorId",
                        column: x => x.FornecedorId,
                        principalTable: "Fornecedores",
                        principalColumn: "FornecedorId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Requisicoes",
                columns: table => new
                {
                    RequisicaoId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Registro = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Data = table.Column<DateTime>(type: "datetime", nullable: false),
                    TamanhoCamisa = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    TamanhoCalca = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    QuantidadeCamisa = table.Column<int>(type: "int", nullable: false),
                    QuantidadeCalca = table.Column<int>(type: "int", nullable: false),
                    QuantidadeLuva = table.Column<int>(type: "int", nullable: false),
                    FuncionarioId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Requisicoes", x => x.RequisicaoId);
                    table.ForeignKey(
                        name: "FK_Requisicoes_Funcionarios_FuncionarioId",
                        column: x => x.FuncionarioId,
                        principalTable: "Funcionarios",
                        principalColumn: "FuncionarioId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_EntregaMateriais_FornecedorId",
                table: "EntregaMateriais",
                column: "FornecedorId");

            migrationBuilder.CreateIndex(
                name: "IX_Funcionarios_Registro",
                table: "Funcionarios",
                column: "Registro",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Requisicoes_FuncionarioId",
                table: "Requisicoes",
                column: "FuncionarioId");

            migrationBuilder.CreateIndex(
                name: "IX_RetiradaMateriais_FornecedorId",
                table: "RetiradaMateriais",
                column: "FornecedorId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "EntregaMateriais");

            migrationBuilder.DropTable(
                name: "Requisicoes");

            migrationBuilder.DropTable(
                name: "RetiradaMateriais");

            migrationBuilder.DropTable(
                name: "Funcionarios");

            migrationBuilder.DropTable(
                name: "Fornecedores");
        }
    }
}
