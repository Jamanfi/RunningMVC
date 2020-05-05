using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RunningMVC.Data.Entities
{
    public class Competitor
    {
        public int Id { get; set; }
        public Runner Runner { get; set; }
        public string FinishTime { get; set; }
    }
}
