namespace DoughnutFactory.Entities
{
    /// <summary>
    /// Tree node structure
    /// </summary>
    public class DoughnutTreeNode
    {
        /// <summary>
        /// Id of the node
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Question of the node
        /// </summary>
        public string Question { get; set; }

        /// <summary>
        /// Positive node id
        /// </summary>
        public int? PositiveNodeId { get; set; }

        /// <summary>
        /// Positive node
        /// </summary>
        public DoughnutTreeNode PositiveNode { get; set; }

        /// <summary>
        /// Negative node if
        /// </summary>
        public int? NegativeNodeId { get; set; }

        /// <summary>
        /// Negative node
        /// </summary>
        public DoughnutTreeNode NegativeNode { get; set; }
    }
}
