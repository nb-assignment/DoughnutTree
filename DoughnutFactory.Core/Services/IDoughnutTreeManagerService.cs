using DoughnutFactory.Entities;
using System.Collections.Generic;

namespace DoughnutFactory.Core.Services
{
    /// <summary>
    /// Interface for tree manager service
    /// </summary>
    public interface IDoughnutTreeManagerService
    {
        /// <summary>
        /// Build the tree structure from tree nodes
        /// </summary>
        /// <param name="node"></param>
        /// <param name="currentEntity"></param>
        /// <param name="entities"></param>
        void BuildTree(DoughnutTree node, DoughnutTreeNode currentEntity, Queue<DoughnutTreeNode> entities);
    }
}
