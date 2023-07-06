using Microsoft.EntityFrameworkCore.Migrations;

namespace CleanArchMVC.Infra.Migrations
{
    public partial class SeedProdutos : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql("INSERT INTO PRODUTOS(Nome, Descricao, Preco, Estoque, Imagem, CategoriaId) " +
                "VALUES ('Caderno espiral', 'Caderno espiral 100 folhas', 7.45, 50, 'caderno1.jpg', 1)");

            migrationBuilder.Sql("INSERT INTO PRODUTOS(Nome, Descricao, Preco, Estoque, Imagem, CategoriaId) " +
                "VALUES ('Calculadora', 'Calculadore simples', 10.90, 25, 'calculadora1.jpg', 2)");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql("DELETE FROM Produtos");
        }
    }
}
