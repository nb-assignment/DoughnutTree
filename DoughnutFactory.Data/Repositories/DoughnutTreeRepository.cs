using DoughnutFactory.Core.Repositories;
using DoughnutFactory.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DoughnutFactory.Data.Repositories
{
    public class DoughnutTreeRepository : Repository<DoughnutTree>, IDoughnutTreeRepository
    {
        public DoughnutTreeRepository(ApplicationDbContext context)
            : base(context)
        { }

        public async Task<IEnumerable<DoughnutTreeNode>> GetDoughnutTreeAsync()
        {
            return await ApplicationDbContext.DoughnutTreeNodes.ToListAsync();
        }

        async ValueTask<DoughnutTreeNode> IRepository<DoughnutTreeNode>.GetByIdAsync(int id)
        {
            return await ApplicationDbContext.DoughnutTreeNodes.FindAsync(id);
        }

        public Task AddAsync(DoughnutTreeNode entity)
        {
            throw new NotImplementedException();
        }

        public void Remove(DoughnutTreeNode entity)
        {
            throw new NotImplementedException();
        }

        Task<IEnumerable<DoughnutTreeNode>> IRepository<DoughnutTreeNode>.GetAllAsync()
        {
            throw new NotImplementedException();
        }

        private ApplicationDbContext ApplicationDbContext
        {
            get { return Context as ApplicationDbContext; }
        }
    }
}
