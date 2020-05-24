using System.Collections.Generic;

namespace DoughnutFactory.Entities
{
    /// <summary>
    /// Tree structure
    /// </summary>
    public class DoughnutTree
    {
        /// <summary>
        /// Id of the node
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Text of the node
        /// </summary>
        public string Text { get; set; }

        /// <summary>
        /// Children of the node
        /// </summary>
        public List<DoughnutTree> Children { get; set; }
    }

    /// <summary>
    /// Extension fot tree
    /// </summary>
    public static class DoughnutTreeExtensions
    {
        /// <summary>
        /// Convert to tree structure from tree node
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        public static DoughnutTree ToDoughnutTree(this DoughnutTreeNode entity)
        {
            // Return tree structure
            return new DoughnutTree
            {
                Id = entity.Id,
                Text = entity.Question
            };
        }
    }
}
