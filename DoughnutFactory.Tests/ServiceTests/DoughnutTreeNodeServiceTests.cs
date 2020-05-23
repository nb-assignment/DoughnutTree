using DoughnutFactory.Core;
using DoughnutFactory.Core.Services;
using DoughnutFactory.Entities;
using DoughnutFactory.Services;
using DoughnutFactory.Tests.MockData;
using Moq;
using System.Threading.Tasks;
using Xunit;

namespace DoughnutFactory.Tests.ServiceTests
{
    public class DoughnutTreeNodeServiceTests
    {
        readonly Mock<IUnitOfWork> _unitOfWork;
        readonly DoughnutTreeService _doughnutTreeNodeService;
        readonly Mock<IDoughnutTreeManagerService> _doughnutTreeManagerService;

        public DoughnutTreeNodeServiceTests()
        {
            _unitOfWork = new Mock<IUnitOfWork>();

            _unitOfWork = new Mock<IUnitOfWork>();

            _doughnutTreeManagerService = new Mock<IDoughnutTreeManagerService>();

            _doughnutTreeNodeService = new DoughnutTreeService(_unitOfWork.Object, _doughnutTreeManagerService.Object);
        }

        [Fact]
        public void GetById_Not_Null()
        {
            //Arrange
            _unitOfWork.Setup(repo => repo.DoughnutTreeRepository.GetByIdAsync(It.IsAny<int>()))
             .Returns(() => new ValueTask<DoughnutTreeNode>(TreeNodeMockData.GetTreeNode()));

            //Act
            var result = _doughnutTreeNodeService.GetById(1);

            //Assert        
            Assert.NotNull(result.Result);
        }

        [Fact]
        public void GetById_Returns_Null()
        {
            //Arrange
            _unitOfWork.Setup(repo => repo.DoughnutTreeRepository.GetByIdAsync(It.IsAny<int>()))
            .Returns(() => new ValueTask<DoughnutTreeNode>((DoughnutTreeNode)null));

            //Act
            var result = _doughnutTreeNodeService.GetById(1);

            //Assert        
            Assert.Null(result.Result);
        }

        [Fact]
        public void GetById_Returns_Task_Return_Type()
        {
            //Arrange
            _unitOfWork.Setup(repo => repo.DoughnutTreeRepository.GetByIdAsync(It.IsAny<int>()))
             .Returns(() => new ValueTask<DoughnutTreeNode>(TreeNodeMockData.GetTreeNode()));

            //Act
            var result = _doughnutTreeNodeService.GetById(1);

            //Assert        
            Assert.IsType<DoughnutTreeNode>(result.Result);
        }

        [Fact]
        public void GetById_Returns_Response_Check()
        {
            //Arrange
            _unitOfWork.Setup(repo => repo.DoughnutTreeRepository.GetByIdAsync(It.IsAny<int>()))
             .Returns(() => new ValueTask<DoughnutTreeNode>(TreeNodeMockData.GetTreeNode()));

            //Act
            var result = _doughnutTreeNodeService.GetById(1);

            //Assert        
            Assert.Equal("Do you need a doughnut?", result.Result.Question);
        }

        [Fact]
        public void GetAll_Returns_NotNull()
        {
            //Arrange
            _unitOfWork.Setup(repo => repo.DoughnutTreeRepository.GetByIdAsync(It.IsAny<int>()))
             .Returns(() => new ValueTask<DoughnutTreeNode>(TreeNodeMockData.GetTreeNode()));

            _unitOfWork.Setup(repo => repo.DoughnutTreeRepository.GetDoughnutTreeAsync())
            .Returns(Task.FromResult(TreeNodeMockData.GetTreeNodes()));

            //Act
            var result = _doughnutTreeNodeService.GetTree();

            //Assert        
            Assert.NotNull(result.Result);
        }

        [Fact]
        public void GetAll_Returns_Null()
        {
            //Arrange
            _unitOfWork.Setup(repo => repo.DoughnutTreeRepository.GetByIdAsync(It.IsAny<int>()))
            .Returns(() => new ValueTask<DoughnutTreeNode>((DoughnutTreeNode)null));

            //Act
            var result = _doughnutTreeNodeService.GetTree();

            //Assert        
            Assert.Null(result.Result);
        }

        [Fact]
        public void GetAll_Returns_Task_Return_Type()
        {
            //Arrange
            _unitOfWork.Setup(repo => repo.DoughnutTreeRepository.GetByIdAsync(It.IsAny<int>()))
             .Returns(() => new ValueTask<DoughnutTreeNode>(TreeNodeMockData.GetTreeNode()));

            _unitOfWork.Setup(repo => repo.DoughnutTreeRepository.GetDoughnutTreeAsync())
            .Returns(Task.FromResult(TreeNodeMockData.GetTreeNodes()));

            //Act
            var result = _doughnutTreeNodeService.GetTree();

            //Assert        
            Assert.IsType<DoughnutTree>(result.Result);
        }

        [Fact]
        public void GetAll_Returns_Response_Check()
        {
            //Arrange
            _unitOfWork.Setup(repo => repo.DoughnutTreeRepository.GetByIdAsync(It.IsAny<int>()))
             .Returns(() => new ValueTask<DoughnutTreeNode>(TreeNodeMockData.GetTreeNode()));

            _unitOfWork.Setup(repo => repo.DoughnutTreeRepository.GetDoughnutTreeAsync())
            .Returns(Task.FromResult(TreeNodeMockData.GetTreeNodes()));

            //Act
            var result = _doughnutTreeNodeService.GetTree();

            //Assert        
            Assert.Equal(1, result.Result.Id);
        }
    }
}
