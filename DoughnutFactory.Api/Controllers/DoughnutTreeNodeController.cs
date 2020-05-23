using System.Threading.Tasks;
using DoughnutFactory.Core.Services;
using DoughnutFactory.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace DoughnutFactory.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DoughnutTreeNodeController : ControllerBase
    {
        private readonly ILogger<DoughnutTreeNodeController> _logger;
        private readonly IDoughnutTreeService _doughnutTreeService;

        public DoughnutTreeNodeController(ILogger<DoughnutTreeNodeController> logger, IDoughnutTreeService doughnutTreeService)
        {
            _doughnutTreeService = doughnutTreeService;
            _logger = logger;
        }

        [HttpGet]
        [Produces(typeof(DoughnutTreeNode))]
        public async Task<IActionResult> GetTree()      
        {
            var questions = await _doughnutTreeService.GetTree();
            return Ok(questions);
        }

        [HttpGet("firstNode")]
        [Produces(typeof(DoughnutTreeNode))]
        public async Task<IActionResult> GetFirstNode()
        {
            var questions = await _doughnutTreeService.GetById(1);
            return Ok(questions);
        }

        [HttpGet("{id}", Name = "Get")]
        public async Task<IActionResult> GetNodeById(int id)
        {
            var questions = await _doughnutTreeService.GetById(id);
            return Ok(questions);
        }
    }
}
