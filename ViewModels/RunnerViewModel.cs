using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using RunningMVC.DataAttributes;

namespace RunningMVC.ViewModels
{
    public class RunnerViewModel
    {
        [Required]
        [MinLength(2)]
        public string Forename { get; set; }
        [Required]
        [MinLength(2)]
        public string Surname { get; set; }
        [Required]
        [DateMinEighteen(ErrorMessage = "Runner must be at least 18 years old.")]
        [DataType(DataType.Date)]
        public DateTime DateOfBirth { get; set; }
        [Required]
        public string Nationality { get; set; }
        public int RunnerId { get; set; }
    }
}
