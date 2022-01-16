using Microsoft.EntityFrameworkCore.Migrations;

namespace Requisicao_RSS.Infra.Data.Migrations
{
    public partial class CampoobservacoesemRequisicoes : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Divergencia",
                table: "Requisicoes",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Observacoes",
                table: "Requisicoes",
                type: "nvarchar(max)",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Divergencia",
                table: "Requisicoes");

            migrationBuilder.DropColumn(
                name: "Observacoes",
                table: "Requisicoes");
        }
    }
}
