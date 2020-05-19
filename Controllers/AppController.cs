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

        [HttpGet]
        public IActionResult Races(int id = -1)
        {
            if (id == -1) id = _repository.GetFirstRace().Id;
            var races = _repository.GetAllRaces(id).ToList();
            ViewBag.raceId = id;
            return View(races);
        }


        [HttpGet]
        public IActionResult Runners()
        {
            ViewBag.Title = "Runners";
            return View();
        }

    }
}