using DoughnutFactory.Entities;
using System.Collections.Generic;

namespace DoughnutFactory.Tests.MockData
{
    /// <summary>
    /// Mock data for the tests
    /// </summary>
    public static class TreeNodeMockData
    {
        /// <summary>
        /// Get test properties
        /// </summary>
        /// <returns></returns>
        public static DoughnutTree GetTree()
        {
            var doughnutTree = new DoughnutTree
            {
                Id = 1,
                Text = "node-1",
                Children = null
            };

            return doughnutTree;
        }

        public static DoughnutTreeNode GetTreeNode()
        {
            var doughnutTreeNode = new DoughnutTreeNode
            {
                Id = 1,
                Question = "Do you need a doughnut?",
                PositiveNodeId = 2,
                NegativeNodeId = 3
            };

            return doughnutTreeNode;
        }

        public static IEnumerable<DoughnutTreeNode> GetTreeNodes()
        {
            var doughnutTreeNodes = new List<DoughnutTreeNode>
            {
                new DoughnutTreeNode()
                {
                    Id = 1,
                    Question = "Question 1",
                    PositiveNodeId = 2,
                    NegativeNodeId = 3
                },
                new DoughnutTreeNode()
                {
                    Id = 2,
                    Question = "Question 2",
                    PositiveNodeId = 4,
                    NegativeNodeId = 5
                }
            };

            return doughnutTreeNodes;
        }
    }
}