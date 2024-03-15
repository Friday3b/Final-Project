using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Final
{
    public class MarketState
    {
        public int CustomerCount { get; set; }
        public double TotalEarnings { get; set; }
        public int DiscardedVegetablesCount { get; set; }
        public int CurrentRating { get; set; }
        public List<WeeklyReport> WeeklyReports { get; set; }



       

        // Diğer metotlar

        


        public MarketState()
        {
            WeeklyReports = new List<WeeklyReport>();
        }



        public void UpdateCustomerCount(int custom)
        {

            CustomerCount += custom;
        }
        public void UpdateTotalEarnings(double amount)
        {
            TotalEarnings += amount;
        }
        public void UpdateDiscardedVegetablesCount(Vegetable vegetable)
        {
            if (vegetable.Condition == Vegetable.State.Toxic)
            {
                DiscardedVegetablesCount++;

            }
        }
        public void UpdateCurrentRating(int rating)
        {

            CurrentRating = rating;
        }
    }





}
