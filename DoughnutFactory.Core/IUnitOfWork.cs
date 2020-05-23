using DoughnutFactory.Core.Repositories;
using System;
using System.Threading.Tasks;

namespace DoughnutFactory.Core
{
    public interface IUnitOfWork : IDisposable
    {
        IDoughnutTreeRepository DoughnutTreeRepository { get; }
        Task<int> CommitAsync();
    }
}
