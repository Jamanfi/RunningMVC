using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RunningMVC.Data.Entities
{
    public class Runner
    {
        public int Id { get; set; }
        public string Forename { get; set; }
        public string Surname { get; set; }
        public string Nationality { get; set; }
        public DateTime DateOfBirth { get; set; }
    }
}
