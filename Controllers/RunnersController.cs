using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Cors;
using RunningMVC.Data;
using RunningMVC.Data.Entities;
using RunningMVC.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace RunningMVC.Controllers
{
    [Route("api/[Controller]")]
    [ApiController]
    [Produces("application/json")]
    public class RunnersController : Controller
    {
        private readonly IRaceRepository _repository;
        private readonly ILogger<RunnersController> _logger;
        private readonly IMapper _mapper;

        public RunnersController(IRaceRepository repository, ILogger<RunnersController> logger, IMapper mapper)
        {
            _repository = repository;
            _logger = logger;
            _mapper = mapper;
        }

        [HttpGet]
        public IActionResult Get()
        {
            try
            
            {
                return Ok(_mapper.Map<IEnumerable<Runner>, IEnumerable<RunnerViewModel>>(_repository.GetAllRunners()));
            }
            catch (Exception ex)
            {
                _logger.LogError($"Failed to get runners: {ex}");
                return BadRequest("Failed to get runners");
            }
        }
        [HttpGet("{id:int}")]
        public IActionResult Get(int id)
        {
            try
            {
                var runner = _repository.GetRunnerById(id);

                if (runner != null) return Ok(_mapper.Map<Runner, RunnerViewModel>(runner));
                return NotFound($"No runner with Id {id} found.");
            }
            catch (Exception ex)
            {
                _logger.LogError($"Failed to get runners: {ex}");
                return BadRequest("Failed to get runners");
            }
        }

        [Authorize]
        [HttpPost]
        public IActionResult CreateRunner([FromForm] RunnerViewModel model)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    var newRunner = _mapper.Map<RunnerViewModel, Runner>(model);
                    _repository.AddEntity(newRunner);
                    if (_repository.SaveAll())
                    {
                        return Created($"/App/Runners/", _mapper.Map<Runner, RunnerViewModel>(newRunner));
                    }
                }
            }
            catch (Exception ex)
            {
                _logger.LogError($"Failed to save a new order: {ex}");
            }

            return BadRequest(ModelState);

        }
    }
}
