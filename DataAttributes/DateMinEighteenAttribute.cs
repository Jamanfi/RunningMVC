using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RunningMVC.DataAttributes
{
    public class DateMinEighteenAttribute : RangeAttribute
    {
        public DateMinEighteenAttribute () 
            : base(typeof(DateTime), DateTime.Now.AddYears(-100).ToShortDateString(), DateTime.Now.AddYears(-18).ToShortDateString())
        {
        }
    }
}
