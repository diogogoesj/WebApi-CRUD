namespace WebApi.Repository.Interfaces.InterfaceSql
{
    /// <summary>
    /// Define uma interface que representa uma unidade de trabalho para operações relacionadas ao banco de dados.
    /// </summary>
    public interface IUnitOfWork
    {
        /// <summary>
        /// Obtém o repositório de produtos associado à unidade de trabalho.
        /// </summary>
        IProdutoRepository ProdutoRepository { get; }

        /// <summary>
        /// Confirma as mudanças realizadas na unidade de trabalho e as persiste no banco de dados.
        /// </summary>
        void Commit();
    }
}

