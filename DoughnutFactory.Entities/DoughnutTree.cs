using System;
using System.Collections.Generic;
using System.Text;

namespace DoughnutFactory.Entities
{
    public class DoughnutTree
    {
        public int Id { get; set; }

        public string Text { get; set; }

        public List<DoughnutTree> Children { get; set; }
    }

    public static class DoughnutTreeNodeExtensions
    {
        public static DoughnutTree ToDoughnutTree(this DoughnutTreeNode entity)
        {
            return new DoughnutTree
            {
                Id = entity.Id,
                Text = entity.Question,
                //Type = type,
            };
        }
    }
}
