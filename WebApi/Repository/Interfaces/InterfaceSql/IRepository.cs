using System.Linq.Expressions;

namespace WebApi.Repository.Interfaces.InterfaceSql
{
    /// <summary>
    /// Define uma interface genérica para operações de repositório com entidades.
    /// </summary>
    /// <typeparam name="T">O tipo de entidade com o qual o repositório opera.</typeparam>
    public interface IRepository<T>
    {
        /// <summary>
        /// Obtém uma consulta IQueryable de entidades do tipo T.
        /// </summary>
        /// <returns>Uma consulta IQueryable de entidades do tipo T.</returns>
        IQueryable<T> Get();

        /// <summary>
        /// Obtém uma entidade do tipo T com base em um predicado.
        /// </summary>
        /// <param name="predicate">O predicado para localizar a entidade.</param>
        /// <returns>A entidade do tipo T que corresponde ao predicado.</returns>
        T GetById(Expression<Func<T, bool>> predicate);

        /// <summary>
        /// Adiciona uma nova entidade do tipo T ao repositório.
        /// </summary>
        /// <param name="entidade">A entidade do tipo T a ser adicionada.</param>
        void Add(T entidade);

        /// <summary>
        /// Atualiza uma entidade do tipo T no repositório.
        /// </summary>
        /// <param name="entidade">A entidade do tipo T a ser atualizada.</param>
        void Update(T entidade);

        /// <summary>
        /// Remove uma entidade do tipo T do repositório.
        /// </summary>
        /// <param name="entidade">A entidade do tipo T a ser removida.</param>
        void Delete(T entidade);
    }
}

