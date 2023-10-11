using Microsoft.EntityFrameworkCore;
using WebApi.Models;

namespace WebApi.Context
{
    /// <summary>
    /// Representa o contexto do banco de dados para a aplicação Web API.
    /// </summary>
    public class ApiDbContext : DbContext
    {
        /// <summary>
        /// Inicializa uma nova instância do contexto do banco de dados com as opções fornecidas.
        /// </summary>
        /// <param name="options">As opções de configuração do contexto do banco de dados.</param>
        public ApiDbContext(DbContextOptions<ApiDbContext> options) : base(options)
        {
        }

        /// <summary>
        /// Obtém ou define a tabela de entidades de produtos no banco de dados.
        /// </summary>
        public DbSet<Produto>? Produtos { get; set; }
    }
}

