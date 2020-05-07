using System;
using System.Collections.Generic;
using System.Linq;

namespace RunningMVC.Data.Entities
{
    public class Race
    {
        public int Id { get; set; }
        public List<Competitor> Competitors { get; set; }
        public float KmLength { get; set; }
        public string Name { get; set; }
        public string Country { get; set; }

        public DateTime EventTime { get; set; }
        
    }
}
