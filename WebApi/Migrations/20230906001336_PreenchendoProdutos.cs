using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WebApi.Migrations
{
    /// <inheritdoc />
    public partial class PreenchendoProdutos : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql("INSERT INTO Produtos(Nome, Preco, Estoque, DataCadastro)" +
               "Values('Bolacha Recheada', 5.45, 50, now())");

            migrationBuilder.Sql("INSERT INTO Produtos(Nome, Preco, Estoque, DataCadastro)" +
               "Values('Mostarda 100g', 3.45, 15, now())");

            migrationBuilder.Sql("INSERT INTO Produtos(Nome, Preco,Estoque, DataCadastro)" +
               "Values('Brahma lata 350ml', 4.40, 100, now())");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql("DELETE FROM Produtos");
        }
    }
}
