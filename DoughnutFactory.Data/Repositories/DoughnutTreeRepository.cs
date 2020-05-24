using DoughnutFactory.Core.Repositories;
using DoughnutFactory.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DoughnutFactory.Data.Repositories
{
    /// <summary>
    /// Tree repository
    /// </summary>
    public class DoughnutTreeRepository : Repository<DoughnutTree>, IDoughnutTreeRepository
    {
        /// <summary>
        /// Constructore
        /// </summary>
        /// <param name="context"></param>
        public DoughnutTreeRepository(ApplicationDbContext context)
            : base(context)
        { }

        /// <summary>
        /// Get all tree nodes
        /// </summary>
        /// <returns></returns>
        public async Task<IEnumerable<DoughnutTreeNode>> GetAllAsync()
        {
            return await ApplicationDbContext.DoughnutTreeNodes.ToListAsync();
        }

        /// <summary>
        /// Get tree nodes by id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        async ValueTask<DoughnutTreeNode> IRepository<DoughnutTreeNode>.GetByIdAsync(int id)
        {
            return await ApplicationDbContext.DoughnutTreeNodes.FindAsync(id);
        }

        /// <summary>
        /// Add a tree node
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        public async Task AddAsync(DoughnutTreeNode entity)
        {
            await ApplicationDbContext.DoughnutTreeNodes.AddAsync(entity);

            await ApplicationDbContext.SaveChangesAsync();

            return;
        }

        /// <summary>
        /// Remove a tree node
        /// </summary>
        /// <param name="entity"></param>
        public async void Remove(DoughnutTreeNode entity)
        {
            ApplicationDbContext.DoughnutTreeNodes.Remove(entity);

            await ApplicationDbContext.SaveChangesAsync();
        }

        /// <summary>
        /// Db ocntext
        /// </summary>
        private ApplicationDbContext ApplicationDbContext
        {
            get { return Context as ApplicationDbContext; }
        }
    }
}
