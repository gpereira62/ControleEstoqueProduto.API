using Microsoft.EntityFrameworkCore.Migrations;

namespace ControleEstoqueProduto.DAL.Migrations
{
    public partial class novoCampoDelete : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "Delete",
                table: "Produtos",
                type: "bit",
                nullable: false,
                defaultValue: false);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Delete",
                table: "Produtos");
        }
    }
}
