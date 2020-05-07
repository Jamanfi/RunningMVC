using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using RunningMVC.Data;
using RunningMVC.Data.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using RunningMVC.ViewModels;

namespace RunningMVC.Controllers
{
    [Route("api/[Controller]")]
    [ApiController]
    [Produces("application/json")]
    public class RacesController : ControllerBase
    {
        private readonly IRaceRepository _repository;
        private readonly ILogger<RacesController> _logger;
        private readonly IMapper _mapper;

        public RacesController(IRaceRepository repository, ILogger<RacesController> logger, IMapper mapper)
        {
            _repository = repository;
            _logger = logger;
            _mapper = mapper;
        }

        [HttpGet]
        [ProducesResponseType(200)]
        [ProducesResponseType(400)]
        public ActionResult<IEnumerable<Race>> Get(int raceId = -1)
        {
            try
            {
                return _repository.GetAllRaces(raceId).ToList();
            }
            catch (Exception ex)
            {
                _logger.LogError($"Failed to get races: {ex}");
                return BadRequest("Failed to get races.");
            }
        }
        [HttpPost]
        public ActionResult CreateCompetitor(int raceId, int runnerId, int seconds)
        {
            try
            {
                var newCompetitor = _repository.AddCompetitor(runnerId, seconds, raceId);

                if (_repository.SaveAll())
                {
                    return Created($"/races/{raceId}", newCompetitor);
                }
                else
                {
                    return BadRequest("Failed to save competitor.");

                }
            }
            catch (Exception ex)
            {
                _logger.LogError($"Failed to save new competitor: {ex}");
                return BadRequest("Failed to save competitor.");
            }
        }

    }
}