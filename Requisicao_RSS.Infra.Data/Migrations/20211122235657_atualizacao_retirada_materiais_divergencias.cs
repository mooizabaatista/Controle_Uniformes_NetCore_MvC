using Microsoft.EntityFrameworkCore.Migrations;

namespace Requisicao_RSS.Infra.Data.Migrations
{
    public partial class atualizacao_retirada_materiais_divergencias : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Divergencia",
                table: "RetiradaMateriais",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Observacoes",
                table: "RetiradaMateriais",
                type: "nvarchar(max)",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Divergencia",
                table: "RetiradaMateriais");

            migrationBuilder.DropColumn(
                name: "Observacoes",
                table: "RetiradaMateriais");
        }
    }
}
