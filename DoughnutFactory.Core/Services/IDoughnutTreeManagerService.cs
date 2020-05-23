using DoughnutFactory.Entities;
using System.Collections.Generic;

namespace DoughnutFactory.Core.Services
{
    public interface IDoughnutTreeManagerService
    {
        void BuildTree(DoughnutTree node, DoughnutTreeNode currentEntity, Queue<DoughnutTreeNode> entities);
    }
}
