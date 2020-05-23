using DoughnutFactory.Core;
using DoughnutFactory.Core.Services;
using DoughnutFactory.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DoughnutFactory.Services
{
    public class DoughnutTreeService : IDoughnutTreeService
    {
        private readonly IUnitOfWork _unitOfWork;

        private readonly IDoughnutTreeManagerService _doughnutTreeManagerService;

        public DoughnutTreeService(IUnitOfWork unitOfWork, IDoughnutTreeManagerService doughnutTreeManagerService)
        {
            _unitOfWork = unitOfWork;
            _doughnutTreeManagerService = doughnutTreeManagerService;
        }
        public async Task<DoughnutTree> GetTree()
        {
            var firstQuestion = await _unitOfWork.DoughnutTreeRepository.GetByIdAsync(1);
            if (firstQuestion == null)
                return null;

            var doughnutTreeNodes = await _unitOfWork.DoughnutTreeRepository.GetDoughnutTreeAsync();

            var entities = new Queue<DoughnutTreeNode>(doughnutTreeNodes);

            var root = entities.Dequeue();
            var result = root.ToDoughnutTree();

            _doughnutTreeManagerService.BuildTree(result, root, entities);

            return result;
        }

        public async Task<DoughnutTreeNode> GetById(int id)
        {
            return await _unitOfWork.DoughnutTreeRepository.GetByIdAsync(id);
        }

        public async Task<DoughnutTreeNode> Create(DoughnutTreeNode newArtist)
        {
            await _unitOfWork.DoughnutTreeRepository
                .AddAsync(newArtist);

            return newArtist;
        }

        public async Task Delete(DoughnutTreeNode artist)
        {
            _unitOfWork.DoughnutTreeRepository.Remove(artist);

            await _unitOfWork.CommitAsync();
        }

        public async Task Update(DoughnutTreeNode artistToBeUpdated, DoughnutTreeNode artist)
        {
            artistToBeUpdated.Question = artist.Question;

            await _unitOfWork.CommitAsync();
        }
    }
}
