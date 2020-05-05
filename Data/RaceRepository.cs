using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RunningMVC.Data.Entities;
using Microsoft.EntityFrameworkCore;

namespace RunningMVC.Data
{
    public class RaceRepository : IRaceRepository
    {
        private readonly RaceContext _context;

        public RaceRepository(RaceContext context)
        {
            _context = context;
        }

        public IEnumerable<Race> GetAllRaces(int raceId = -1)
        {
            var races = _context.Races
                .OrderBy(r => r.EventTime)
                .ToList();

            races.FirstOrDefault(r => r.Id == raceId).Competitors = _context.Races
                .Where(r => r.Id == raceId)
                .Include(r => r.Competitors)
                .ThenInclude(r => r.Runner)
                .First().Competitors;

            return races;
        }

        public Race GetRaceById(int id)
        {
            return _context.Races
                .Where(r => r.Id == id)
                .Include(r => r.Competitors)
                .ThenInclude(r => r.Runner)
                .FirstOrDefault();
        }

        public Race GetFirstRace()
        {
            return _context.Races.OrderBy(r => r.EventTime).First();
        }

        public IEnumerable<Runner> GetAllRunners()
        {
            return _context.Runners.ToList();
        }

        public Runner GetRunnerById(int id)
        {
            return _context.Runners.Find(id);

        }

        public void AddEntity(object model)
        {
            _context.Add(model);
        }

        public bool SaveAll()
        {
           return _context.SaveChanges() > 0;
        }
    }
}
