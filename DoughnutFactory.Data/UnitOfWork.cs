using DoughnutFactory.Core;
using DoughnutFactory.Core.Repositories;
using DoughnutFactory.Data.Repositories;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace DoughnutFactory.Data
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly ApplicationDbContext _context;
        private DoughnutTreeRepository _doughnutTreeRepository;

        public UnitOfWork(ApplicationDbContext context)
        {
            this._context = context;
        }

        public IDoughnutTreeRepository DoughnutTreeRepository => _doughnutTreeRepository = _doughnutTreeRepository ?? new DoughnutTreeRepository(_context);

        public async Task<int> CommitAsync()
        {
            return await _context.SaveChangesAsync();
        }

        public void Dispose()
        {
            _context.Dispose();
        }
    }
}
