using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Final
{
    public class WeeklyReport
    {
        public DateTime WeekStartDate { get; set; }
        public int CustomerCount { get; set; }
        public double TotalEarnings { get; set; }
        public int DiscardedVegetablesCount { get; set; }
        public int CurrentRating { get; set; }
    }

}
