using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using RunningMVC.Data;
using RunningMVC.Data.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace RunningMVC.Controllers
{
    [Route("api/[Controller]")]
    [ApiController]
    [Produces("application/json")]
    public class RacesController : ControllerBase
    {
        private readonly IRaceRepository _repository;
        private readonly ILogger<RacesController> _logger;

        public RacesController(IRaceRepository repository, ILogger<RacesController> logger)
        {
            _repository = repository;
            _logger = logger;
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

    }
}