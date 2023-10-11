using WebApi.Context;
using WebApi.Repository.Interfaces.InterfaceSql;

namespace WebApi.Repository.RepositorySql
{
    /// <summary>
    /// Implementação da interface IUnitOfWork para coordenação de repositórios e confirmação de mudanças no banco de dados.
    /// </summary>
    public class UnitOfWork : IUnitOfWork
    {
        private ProdutoRepository? _produtoRepository;
        public ApiDbContext _contexto;

        /// <summary>
        /// Inicializa uma nova instância da unidade de trabalho com o contexto do banco de dados.
        /// </summary>
        /// <param name="contexto">O contexto do banco de dados usado para acessar os dados.</param>
        public UnitOfWork(ApiDbContext contexto)
        {
            _contexto = contexto;
        }

        /// <summary>
        /// Obtém o repositório de produtos associado à unidade de trabalho.
        /// </summary>
        public IProdutoRepository ProdutoRepository
        {
            get
            {
                return _produtoRepository = _produtoRepository ?? new ProdutoRepository(_contexto);
            }
        }

        /// <summary>
        /// Confirma e persiste as mudanças realizadas na unidade de trabalho no banco de dados.
        /// </summary>
        public void Commit()
        {
            _contexto.SaveChanges();
        }

        /// <summary>
        /// Libera os recursos do contexto do banco de dados quando a unidade de trabalho é descartada.
        /// </summary>
        public void Dispose()
        {
            _contexto.Dispose();
        }
    }
}
