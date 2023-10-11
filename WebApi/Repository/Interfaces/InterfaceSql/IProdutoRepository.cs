using WebApi.Models;

namespace WebApi.Repository.Interfaces.InterfaceSql
{
    /// <summary>
    /// Define uma interface para operações de repositório relacionadas a produtos em um banco de dados.
    /// </summary>
    public interface IProdutoRepository : IRepository<Produto>
    {
    }
}
