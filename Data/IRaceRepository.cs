using System.Collections.Generic;
using RunningMVC.Data.Entities;
using Microsoft.AspNetCore.Mvc;

namespace RunningMVC.Data
{
    public interface IRaceRepository
    {
        IEnumerable<Race> GetAllRaces(int raceId);

        Race GetRaceById(int id);

        Race GetFirstRace();

        IEnumerable<Runner> GetAllRunners();
        Runner GetRunnerById(int id);
        void AddEntity(object model);
        bool SaveAll();
        Competitor AddCompetitor(int runnerId, int seconds, int raceId);
    }
}