using System.Threading.Tasks;
using DoughnutFactory.Core.Services;
using DoughnutFactory.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace DoughnutFactory.Api.Controllers
{
    /// <summary>
    /// Tree node controller
    /// </summary>
    [Route("api/[controller]")]
    [ApiController]
    public class DoughnutTreeNodeController : ControllerBase
    {
        /// <summary>
        /// Logger instance
        /// </summary>
        private readonly ILogger<DoughnutTreeNodeController> _logger;

        /// <summary>
        /// tree service instance
        /// </summary>
        private readonly IDoughnutTreeService _doughnutTreeService;

        /// <summary>
        /// Constructore
        /// </summary>
        /// <param name="logger"></param>
        /// <param name="doughnutTreeService"></param>
        public DoughnutTreeNodeController(ILogger<DoughnutTreeNodeController> logger, IDoughnutTreeService doughnutTreeService)
        {
            _doughnutTreeService = doughnutTreeService;
            _logger = logger;
        }

        /// <summary>
        /// Get the tree structure from tree nodes
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [Produces(typeof(DoughnutTree))]
        public async Task<IActionResult> GetTree()      
        {
            var tree = await _doughnutTreeService.GetTree();

            if (tree == null)
            {
                return NotFound("Tree not found");
            }

            return Ok(tree);
        }

        /// <summary>
        /// Get the first tree node to start the game
        /// </summary>
        /// <returns></returns>
        [HttpGet("firstNode")]
        [Produces(typeof(DoughnutTreeNode))]
        public async Task<IActionResult> GetFirstNode()
        {
            var treeNode = await _doughnutTreeService.GetById(1);

            if (treeNode == null)
            {
                return NotFound("Tree node not found");
            }

            return Ok(treeNode);
        }

        /// <summary>
        /// Get the tree nodes by its id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet("{id}", Name = "Get")]
        public async Task<IActionResult> GetNodeById(int id)
        {
            if(id == 0)
            {
                return BadRequest();
            }

            var treeNode = await _doughnutTreeService.GetById(id);

            if(treeNode == null)
            {
                return NotFound("Tree node not found");
            }

            return Ok(treeNode);
        }
    }
}
