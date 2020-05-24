using DoughnutFactory.Core;
using DoughnutFactory.Core.Repositories;
using DoughnutFactory.Data.Repositories;
using System.Threading.Tasks;

namespace DoughnutFactory.Data
{
    /// <summary>
    /// Unit of work
    /// </summary>
    public class UnitOfWork : IUnitOfWork
    {
        /// <summary>
        /// Db context
        /// </summary>
        private readonly ApplicationDbContext _context;

        /// <summary>
        /// Tree repository
        /// </summary>
        private DoughnutTreeRepository _doughnutTreeRepository;

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="context"></param>
        public UnitOfWork(ApplicationDbContext context)
        {
            this._context = context;
        }

        /// <summary>
        /// Tree repo get
        /// </summary>
        public IDoughnutTreeRepository DoughnutTreeRepository => _doughnutTreeRepository = _doughnutTreeRepository ?? new DoughnutTreeRepository(_context);

        /// <summary>
        /// Commit the transaction
        /// </summary>
        /// <returns></returns>
        public async Task<int> CommitAsync()
        {
            return await _context.SaveChangesAsync();
        }

        /// <summary>
        /// Dispose the context
        /// </summary>
        public void Dispose()
        {
            _context.Dispose();
        }
    }
}
