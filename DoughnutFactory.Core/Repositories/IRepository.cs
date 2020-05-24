using System.Collections.Generic;
using System.Threading.Tasks;

namespace DoughnutFactory.Core.Repositories
{
    /// <summary>
    /// Interface for repository
    /// </summary>
    /// <typeparam name="TEntity"></typeparam>
    public interface IRepository<TEntity> where TEntity : class
    {
        /// <summary>
        /// Get by id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        ValueTask<TEntity> GetByIdAsync(int id);

        /// <summary>
        /// Get all
        /// </summary>
        /// <returns></returns>
        Task<IEnumerable<TEntity>> GetAllAsync();   

        /// <summary>
        /// Add the entity
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        Task AddAsync(TEntity entity);

        /// <summary>
        /// Remove the entity
        /// </summary>
        /// <param name="entity"></param>
        void Remove(TEntity entity);
    }
}
