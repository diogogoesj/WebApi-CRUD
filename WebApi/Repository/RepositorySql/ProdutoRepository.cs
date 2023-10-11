using WebApi.Context;
using WebApi.Models;
using WebApi.Repository.Interfaces.InterfaceSql;

namespace WebApi.Repository.RepositorySql
{
    /// <summary>
    /// Implementação concreta do repositório de produtos que se baseia na classe genérica Repository.
    /// </summary>
    public class ProdutoRepository : Repository<Produto>, IProdutoRepository
    {
        /// <summary>
        /// Inicializa uma nova instância do repositório de produtos com o contexto do banco de dados.
        /// </summary>
        /// <param name="contexto">O contexto do banco de dados usado para acessar os dados dos produtos.</param>
        public ProdutoRepository(ApiDbContext contexto) : base(contexto)
        {

        }
    }
}

