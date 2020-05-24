using DoughnutFactory.Entities;
using System.Threading.Tasks;

namespace DoughnutFactory.Core.Services
{
    /// <summary>
    /// Interface for tree service
    /// </summary>
    public interface IDoughnutTreeService
    {
        /// <summary>
        /// Get the tree structure
        /// </summary>
        /// <returns></returns>
        Task<DoughnutTree> GetTree();

        /// <summary>
        /// Get tree node by id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        Task<DoughnutTreeNode> GetById(int id);

        /// <summary>
        /// Create new tree node
        /// </summary>
        /// <param name="newItem"></param>
        /// <returns></returns>
        Task<DoughnutTreeNode> Create(DoughnutTreeNode newItem);

        /// <summary>
        /// Update the tree node
        /// </summary>
        /// <param name="doughnutTreeNodeToBeUpdated"></param>
        /// <param name="doughnutTreeNode"></param>
        /// <returns></returns>
        Task Update(DoughnutTreeNode doughnutTreeNodeToBeUpdated, DoughnutTreeNode doughnutTreeNode);

        /// <summary>
        /// Remove the tree node
        /// </summary>
        /// <param name="doughnutTreeNode"></param>
        /// <returns></returns>
        Task Delete(DoughnutTreeNode doughnutTreeNode);
    }
}
