using DoughnutFactory.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace DoughnutFactory.Core.Services
{
    public interface IDoughnutTreeService
    {
        Task<DoughnutTree> GetTree();
        Task<DoughnutTreeNode> GetById(int id);
        Task<DoughnutTreeNode> Create(DoughnutTreeNode newItem);
        Task Update(DoughnutTreeNode doughnutTreeNodeToBeUpdated, DoughnutTreeNode doughnutTreeNode);
        Task Delete(DoughnutTreeNode doughnutTreeNode);
    }
}
