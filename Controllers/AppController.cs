using Microsoft.AspNetCore.Mvc;
using System;
using RunningMVC.ViewModels;
using RunningMVC.Data;
using System.Linq;
using RunningMVC.Data.Entities;

namespace RunningMVC.Controllers
{
    public class AppController : Controller
    {
        private readonly IRaceRepository _repository;
        public AppController(IRaceRepository repository)
        {
            _repository = repository;
        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpGet("races")]
        public IActionResult Races(int raceId = -1)
        {
            if (raceId == -1) raceId = _repository.GetFirstRace().Id;
            var races = _repository.GetAllRaces(raceId).ToList();
            ViewBag.raceId = raceId;
            return View(races);
        }


        [HttpGet("runners")]
        public IActionResult Runners()
        {
            ViewBag.Title = "Runners";
            return View();
        }

    }
}