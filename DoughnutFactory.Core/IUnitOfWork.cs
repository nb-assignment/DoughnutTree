using DoughnutFactory.Core.Repositories;
using System;
using System.Threading.Tasks;

namespace DoughnutFactory.Core
{
    /// <summary>
    /// Interface for unit of work
    /// </summary>
    public interface IUnitOfWork : IDisposable
    {
        /// <summary>
        /// Tree repository
        /// </summary>
        IDoughnutTreeRepository DoughnutTreeRepository { get; }

        /// <summary>
        /// Commit the transaction
        /// </summary>
        /// <returns></returns>
        Task<int> CommitAsync();
    }
}
