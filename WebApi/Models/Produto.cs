using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebApi.Models
{
    /// <summary>
    /// Representa um produto em um sistema web.
    /// </summary>
    public class Produto
    {
        /// <summary>
        /// Obtém ou define o ID único do produto.
        /// </summary>
        [Key]
        public int ProdutoId { get; set; }

        /// <summary>
        /// Obtém ou define o nome do produto.
        /// </summary>
        [Required]
        [StringLength(100)]
        public string? Nome { get; set; }

        /// <summary>
        /// Obtém ou define o preço do produto com precisão de 10 dígitos e 2 casas decimais.
        /// </summary>
        [Required]
        [Column(TypeName = "decimal(10,2)")]
        public decimal Preco { get; set; }

        /// <summary>
        /// Obtém ou define a quantidade em estoque do produto.
        /// </summary>
        public float Estoque { get; set; }

        /// <summary>
        /// Obtém ou define a data de cadastro do produto.
        /// </summary>
        public DateTime DataCadastro { get; set; }

        /// <summary>
        /// Obtém ou define o valor total do produto (não mapeado para o banco de dados).
        /// </summary>
        [NotMapped]
        public decimal ValorTotal { get; set; }

        /// <summary>
        /// Calcula o valor total do produto multiplicando o preço pelo estoque.
        /// </summary>
        public void CalcularValorTotal()
        {
            ValorTotal = Preco * (decimal)Estoque;
        }
    }
}



