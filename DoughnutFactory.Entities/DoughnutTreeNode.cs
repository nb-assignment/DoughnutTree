using System;
using System.Collections.Generic;
using System.Text;

namespace DoughnutFactory.Entities
{
    public class DoughnutTreeNode
    {
        public int Id { get; set; }

        public string Question { get; set; }

        public int? PositiveNodeId { get; set; }

        public DoughnutTreeNode PositiveNode { get; set; }

        public int? NegativeNodeId { get; set; }

        public DoughnutTreeNode NegativeNode { get; set; }
    }
}
