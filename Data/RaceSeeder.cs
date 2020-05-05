using RunningMVC.Data.Entities;
using Microsoft.AspNetCore.Hosting;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace RunningMVC.Data
{
    public class RaceSeeder
    {
        private readonly RaceContext _ctx;
        private readonly IWebHostEnvironment _hosting;

        public RaceSeeder(RaceContext ctx, IWebHostEnvironment hosting)
        {
            _ctx = ctx;
            _hosting = hosting;
        }

        public void Seed()
        {
            _ctx.Database.EnsureCreated();

            if (!_ctx.Runners.Any())
            {
                var filepath = Path.Combine(_hosting.ContentRootPath, "Data\\Runners.json");
                var json = File.ReadAllText(filepath);
                var runners = JsonConvert.DeserializeObject<IEnumerable<Runner>>(json);
                _ctx.Runners.AddRange(runners);
                _ctx.SaveChanges();
            }

            if (!_ctx.Races.Any())
            {
                var filepath = Path.Combine(_hosting.ContentRootPath, "Data\\Races.json");
                var json = File.ReadAllText(filepath);
                var races = JsonConvert.DeserializeObject<IEnumerable<Race>>(json);

                _ctx.Races.AddRange(races);
                _ctx.SaveChanges();
            }

            if (!_ctx.Competitors.Any())
            {
                _ctx.Races.First(r => r.EventTime.Date == new DateTime(2019, 04, 30)).Competitors = new List<Competitor>()
                {
                    new Competitor()
                    {
                        Runner = _ctx.Runners.First(ru => ru.DateOfBirth.Date == new DateTime(1993, 04, 23)),
                        FinishTime = "02:21:12"
                    },
                    new Competitor()
                    {
                        Runner = _ctx.Runners.First(ru => ru.Surname == "Phippen"),
                        FinishTime = "02:42:16"
                    }
                };

                _ctx.Races.First(r => r.EventTime.Date == new DateTime(2019, 11, 14)).Competitors = new List<Competitor>()
                {
                    new Competitor()
                    {
                        Runner = _ctx.Runners.First(ru => ru.DateOfBirth.Date == new DateTime(1993, 04, 23)),
                        FinishTime = "01:50:46"
                    }
                };

                _ctx.Races.First(r => r.EventTime.Date == new DateTime(2019, 12, 23)).Competitors = new List<Competitor>()
                {
                    new Competitor()
                    {
                        Runner = _ctx.Runners.First(ru => ru.DateOfBirth.Date == new DateTime(1993, 04, 23)),
                        FinishTime = "04:51:41"
                    },
                    new Competitor()
                    {
                        Runner = _ctx.Runners.First(ru => ru.DateOfBirth.Date == new DateTime(1990, 11, 21)),
                        FinishTime = "04:46:25"
                    }
                };


                _ctx.SaveChanges();
            }


        }


    }
}
