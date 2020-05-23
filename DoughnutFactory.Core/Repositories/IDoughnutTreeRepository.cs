using DoughnutFactory.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace DoughnutFactory.Core.Repositories
{
    public interface IDoughnutTreeRepository : IRepository<DoughnutTreeNode>
    {
        Task<IEnumerable<DoughnutTreeNode>> GetDoughnutTreeAsync();
    }
}
