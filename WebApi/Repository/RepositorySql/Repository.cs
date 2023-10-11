using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;
using WebApi.Context;
using WebApi.Repository.Interfaces.InterfaceSql;

namespace WebApi.Repository.RepositorySql
{
    /// <summary>
    /// Classe genérica que implementa as operações comuns de repositório para entidades do tipo T.
    /// </summary>
    /// <typeparam name="T">O tipo de entidade com a qual o repositório opera.</typeparam>
    public class Repository<T> : IRepository<T> where T : class
    {
        protected ApiDbContext _contexto;

        /// <summary>
        /// Inicializa uma nova instância do repositório com o contexto do banco de dados.
        /// </summary>
        /// <param name="contexto">O contexto do banco de dados usado para acessar os dados.</param>
        public Repository(ApiDbContext contexto)
        {
            _contexto = contexto;
        }

        /// <summary>
        /// Obtém uma consulta IQueryable de entidades do tipo T.
        /// </summary>
        /// <returns>Uma consulta IQueryable de entidades do tipo T.</returns>
        public IQueryable<T> Get()
        {
            return _contexto.Set<T>().AsNoTracking();
        }

        /// <summary>
        /// Obtém uma entidade do tipo T com base em um predicado.
        /// </summary>
        /// <param name="predicate">O predicado para localizar a entidade.</param>
        /// <returns>A entidade do tipo T que corresponde ao predicado.</returns>
        public T GetById(Expression<Func<T, bool>> predicate)
        {
            return _contexto.Set<T>().SingleOrDefault(predicate);
        }

        /// <summary>
        /// Adiciona uma nova entidade do tipo T ao repositório.
        /// </summary>
        /// <param name="entidade">A entidade do tipo T a ser adicionada.</param>
        public void Add(T entidade)
        {
            _contexto.Set<T>().Add(entidade);
        }

        /// <summary>
        /// Remove uma entidade do tipo T do repositório.
        /// </summary>
        /// <param name="entidade">A entidade do tipo T a ser removida.</param>
        public void Delete(T entidade)
        {
            _contexto.Set<T>().Remove(entidade);
        }

        /// <summary>
        /// Atualiza uma entidade do tipo T no repositório.
        /// </summary>
        /// <param name="entidade">A entidade do tipo T a ser atualizada.</param>
        public void Update(T entidade)
        {
            _contexto.Set<T>().Update(entidade);
        }
    }
}

