using DoughnutFactory.Core;
using DoughnutFactory.Core.Services;
using DoughnutFactory.Entities;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DoughnutFactory.Services
{
    /// <summary>
    /// Tree service
    /// </summary>
    public class DoughnutTreeService : IDoughnutTreeService
    {
        /// <summary>
        /// Unit of work
        /// </summary>
        private readonly IUnitOfWork _unitOfWork;

        /// <summary>
        /// Tree manager service
        /// </summary>
        private readonly IDoughnutTreeManagerService _doughnutTreeManagerService;

        /// <summary>
        /// Constructore
        /// </summary>
        /// <param name="unitOfWork"></param>
        /// <param name="doughnutTreeManagerService"></param>
        public DoughnutTreeService(IUnitOfWork unitOfWork, IDoughnutTreeManagerService doughnutTreeManagerService)
        {
            _unitOfWork = unitOfWork;
            _doughnutTreeManagerService = doughnutTreeManagerService;
        }

        /// <summary>
        /// Get the tree structure
        /// </summary>
        /// <returns></returns>
        public async Task<DoughnutTree> GetTree()
        {
            // Get all nodes of the tree
            var doughnutTreeNodes = await _unitOfWork.DoughnutTreeRepository.GetAllAsync();

            if(doughnutTreeNodes == null || doughnutTreeNodes.Count() == 0)
            {
                return null;
            }

            // Queue the nodes
            var entities = new Queue<DoughnutTreeNode>(doughnutTreeNodes);

            // Dequeue the first node
            var root = entities.Dequeue();

            // Convert to tree structure except the children
            var result = root.ToDoughnutTree();

            // Build the tree
            _doughnutTreeManagerService.BuildTree(result, root, entities);

            // Return the tree
            return result;
        }

        /// <summary>
        /// Get the node by id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public async Task<DoughnutTreeNode> GetById(int id)
        {
            return await _unitOfWork.DoughnutTreeRepository.GetByIdAsync(id);
        }

        /// <summary>
        /// Create the node
        /// </summary>
        /// <param name="newNode"></param>
        /// <returns></returns>
        public async Task<DoughnutTreeNode> Create(DoughnutTreeNode newNode)
        {
            await _unitOfWork.DoughnutTreeRepository
                .AddAsync(newNode);

            return newNode;
        }

        /// <summary>
        /// Delete the node
        /// </summary>
        /// <param name="node"></param>
        /// <returns></returns>
        public async Task Delete(DoughnutTreeNode node)
        {
            _unitOfWork.DoughnutTreeRepository.Remove(node);

            await _unitOfWork.CommitAsync();
        }

        /// <summary>
        /// Update the node
        /// </summary>
        /// <param name="nodeToBeUpdated"></param>
        /// <param name="node"></param>
        /// <returns></returns>
        public async Task Update(DoughnutTreeNode nodeToBeUpdated, DoughnutTreeNode node)
        {
            nodeToBeUpdated.Question = node.Question;

            await _unitOfWork.CommitAsync();
        }
    }
}
