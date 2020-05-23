using DoughnutFactory.Core.Services;
using DoughnutFactory.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace DoughnutFactory.Services
{
    public class DoughnutTreeManagerService : IDoughnutTreeManagerService
    {
        public void BuildTree(DoughnutTree node, DoughnutTreeNode currentEntity, Queue<DoughnutTreeNode> entities)
        {
            if (currentEntity.PositiveNodeId.HasValue || currentEntity.NegativeNodeId.HasValue)
                node.Children = new List<DoughnutTree>();
            else
            {
                return;
            }

            DoughnutTreeNode positiveEntity = null;
            DoughnutTree positiveNode = null;

            DoughnutTreeNode negativeEntity = null;
            DoughnutTree negativeNode = null;

            if (currentEntity.PositiveNodeId.HasValue)
            {
                positiveEntity = entities.Dequeue();
                positiveNode = positiveEntity.ToDoughnutTree();
                node.Children.Add(positiveNode);
            }

            if (currentEntity.NegativeNodeId.HasValue)
            {
                negativeEntity = entities.Dequeue();
                negativeNode = negativeEntity.ToDoughnutTree();
                node.Children.Add(negativeNode);
            }

            if (negativeNode != null)
                BuildTree(negativeNode, negativeEntity, entities);

            if (positiveEntity != null)
                BuildTree(positiveNode, positiveEntity, entities);
        }
    }
}
