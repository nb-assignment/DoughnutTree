using DoughnutFactory.Core.Services;
using DoughnutFactory.Entities;
using System.Collections.Generic;

namespace DoughnutFactory.Services
{
    /// <summary>
    /// Tree manager service
    /// </summary>
    public class DoughnutTreeManagerService : IDoughnutTreeManagerService
    {
        /// <summary>
        /// Build the tree from tree nodes
        /// </summary>
        /// <param name="node"></param>
        /// <param name="currentEntity"></param>
        /// <param name="entities"></param>
        public void BuildTree(DoughnutTree node, DoughnutTreeNode currentEntity, Queue<DoughnutTreeNode> entities)
        {
            // If positive or negative node if is available, go ahead else return
            if (currentEntity.PositiveNodeId.HasValue || currentEntity.NegativeNodeId.HasValue)
                node.Children = new List<DoughnutTree>();
            else
            {
                return;
            }

            // Initialization
            DoughnutTreeNode positiveEntity = null;
            DoughnutTree positiveNode = null;

            DoughnutTreeNode negativeEntity = null;
            DoughnutTree negativeNode = null;

            // If positive node is available, add it as a child
            if (currentEntity.PositiveNodeId.HasValue)
            {
                positiveEntity = entities.Dequeue();
                positiveNode = positiveEntity.ToDoughnutTree();
                node.Children.Add(positiveNode);
            }

            // If negative node is available, add it as a child
            if (currentEntity.NegativeNodeId.HasValue)
            {
                negativeEntity = entities.Dequeue();
                negativeNode = negativeEntity.ToDoughnutTree();
                node.Children.Add(negativeNode);
            }

            // Continue building tree if negative node is not null
            if (negativeNode != null)
                BuildTree(negativeNode, negativeEntity, entities);

            // Continue building tree if positive node is not null
            if (positiveEntity != null)
                BuildTree(positiveNode, positiveEntity, entities);
        }
    }
}
