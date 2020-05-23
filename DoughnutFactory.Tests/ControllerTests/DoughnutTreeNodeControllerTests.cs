using DoughnutFactory.Api.Controllers;
using DoughnutFactory.Core.Services;
using DoughnutFactory.Entities;
using DoughnutFactory.Tests.MockData;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Moq;
using Xunit;

namespace DoughnutFactory.Tests.ControllerTests
{
    public class DoughnutTreeNodeServiceTests
    {
        readonly Mock<ILogger<DoughnutTreeNodeController>> _loggerService;
        readonly Mock<IDoughnutTreeService> _doughnutTreeService;
        readonly DoughnutTreeNodeController _doughnutTreeNodeController;

        public DoughnutTreeNodeServiceTests()
        {
            _doughnutTreeService = new Mock<IDoughnutTreeService>();
            _loggerService = new Mock<ILogger<DoughnutTreeNodeController>>();

            _doughnutTreeNodeController = new DoughnutTreeNodeController(_loggerService.Object, _doughnutTreeService.Object);
        }

        [Fact]
        public void GetTree_Not_Null()
        {
            //Arrange
            _doughnutTreeService.Setup(repo => repo.GetAll()).ReturnsAsync(TreeNodeMockData.GetTree());

            //Act
            var result = _doughnutTreeNodeController.GetTree();

            //Assert        
            Assert.NotNull(result.Result);
        }

        [Fact]
        public void GetTree_Returns_Null()
        {
            //Arrange
            _doughnutTreeService.Setup(repo => repo.GetAll()).ReturnsAsync((DoughnutTree)null);

            //Act
            var result = _doughnutTreeNodeController.GetTree();

            //Assert        
            var okObjectResult = Assert.IsType<OkObjectResult>(result.Result);
            Assert.Null(okObjectResult.Value);
        }

        [Fact]
        public void GetTree_ReturnsOk_Return_Type()
        {
            //Arrange
            _doughnutTreeService.Setup(repo => repo.GetAll()).ReturnsAsync(TreeNodeMockData.GetTree());

            //Act
            var result = _doughnutTreeNodeController.GetTree();

            //Assert
            Assert.IsType<OkObjectResult>(result.Result);
        }

        [Fact]
        public void GetTree_ReturnsOk_Response_Check()
        {
            //Arrange
            _doughnutTreeService.Setup(repo => repo.GetAll()).ReturnsAsync(TreeNodeMockData.GetTree());

            //Act
            var result = _doughnutTreeNodeController.GetTree();

            //Assert
            var okObjectResult = Assert.IsType<OkObjectResult>(result.Result);
            var model = Assert.IsAssignableFrom<DoughnutTree>(
                okObjectResult.Value);
            Assert.Equal("node-1", model.Text);
        }

        [Fact]
        public void GetFirstNode_Not_Null()
        {
            //Arrange
            _doughnutTreeService.Setup(repo => repo.GetById(It.IsAny<int>())).ReturnsAsync(TreeNodeMockData.GetTreeNode());

            //Act
            var result = _doughnutTreeNodeController.GetFirstNode();

            //Assert        
            Assert.NotNull(result.Result);
        }

        [Fact]
        public void GetFirstNode_Returns_Null()
        {
            //Arrange
            _doughnutTreeService.Setup(repo => repo.GetById(It.IsAny<int>())).ReturnsAsync((DoughnutTreeNode)null);

            //Act
            var result = _doughnutTreeNodeController.GetFirstNode();

            //Assert        
            var okObjectResult = Assert.IsType<OkObjectResult>(result.Result);
            Assert.Null(okObjectResult.Value);
        }

        [Fact]
        public void GetFirstNode_ReturnsOk_Return_Type()
        {
            //Arrange
            _doughnutTreeService.Setup(repo => repo.GetById(It.IsAny<int>())).ReturnsAsync(TreeNodeMockData.GetTreeNode());

            //Act
            var result = _doughnutTreeNodeController.GetFirstNode();

            //Assert
            Assert.IsType<OkObjectResult>(result.Result);
        }

        [Fact]
        public void GetFirstNode_ReturnsOk_Response_Check()
        {
            //Arrange
            _doughnutTreeService.Setup(repo => repo.GetById(It.IsAny<int>())).ReturnsAsync(TreeNodeMockData.GetTreeNode());

            //Act
            var result = _doughnutTreeNodeController.GetFirstNode();

            //Assert
            var okObjectResult = Assert.IsType<OkObjectResult>(result.Result);
            var model = Assert.IsAssignableFrom<DoughnutTreeNode>(
                okObjectResult.Value);
            Assert.Equal("Do you need a doughnut?", model.Question);
        }

        [Fact]
        public void GetNodeById_Not_Null()
        {
            //Arrange
            _doughnutTreeService.Setup(repo => repo.GetById(It.IsAny<int>())).ReturnsAsync(TreeNodeMockData.GetTreeNode());

            //Act
            var result = _doughnutTreeNodeController.GetNodeById(1);

            //Assert        
            Assert.NotNull(result.Result);
        }

        [Fact]
        public void GetNodeById_Returns_Null()
        {
            //Arrange
            _doughnutTreeService.Setup(repo => repo.GetById(It.IsAny<int>())).ReturnsAsync((DoughnutTreeNode)null);

            //Act
            var result = _doughnutTreeNodeController.GetNodeById(1);

            //Assert        
            var okObjectResult = Assert.IsType<OkObjectResult>(result.Result);
            Assert.Null(okObjectResult.Value);
        }

        [Fact]
        public void GetNodeById_ReturnsOk_Return_Type()
        {
            //Arrange
            _doughnutTreeService.Setup(repo => repo.GetById(It.IsAny<int>())).ReturnsAsync(TreeNodeMockData.GetTreeNode());

            //Act
            var result = _doughnutTreeNodeController.GetNodeById(1);

            //Assert
            Assert.IsType<OkObjectResult>(result.Result);
        }

        [Fact]
        public void GetNodeById_ReturnsOk_Response_Check()
        {
            //Arrange
            _doughnutTreeService.Setup(repo => repo.GetById(It.IsAny<int>())).ReturnsAsync(TreeNodeMockData.GetTreeNode());

            //Act
            var result = _doughnutTreeNodeController.GetNodeById(1);

            //Assert
            var okObjectResult = Assert.IsType<OkObjectResult>(result.Result);
            var model = Assert.IsAssignableFrom<DoughnutTreeNode>(
                okObjectResult.Value);
            Assert.Equal("Do you need a doughnut?", model.Question);
        }
    }
}
