using Microsoft.EntityFrameworkCore.Migrations;

namespace ControleEstoqueProduto.DAL.Migrations
{
    public partial class ValidacaoNomeIndexRemovida : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Produtos_Nome",
                table: "Produtos");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateIndex(
                name: "IX_Produtos_Nome",
                table: "Produtos",
                column: "Nome",
                unique: true);
        }
    }
}
