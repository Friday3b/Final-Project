using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;


namespace Final
{
    public class MarketManager
    {
        public Market market { get; set; }
        public MarketState marketState { get; set; }

        public MarketManager(Market market)
        {
            this.market = market;
            this.marketState = new MarketState();
        }

        public void SerializeMarketState(string filePath)
        {
            try
            {
                string jsonString = JsonSerializer.Serialize(marketState, options: new JsonSerializerOptions() { WriteIndented = true });
                File.WriteAllText(filePath, jsonString);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Diqqet : {ex.Message}");
            }
        }

        public void DeserializeMarketState(string filePath)
        {
            try
            {
                string jsonString = File.ReadAllText(filePath);
                marketState = JsonSerializer.Deserialize<MarketState>(jsonString);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error bash verdi oxuma zamani : {ex.Message}");
            }
        }

        public void GenerateWeeklyReport()
        {
            for (int i = 0; i < 7; i++)
            {
                for (int j = 0; j < 3; j++)
                {


                    marketState.UpdateTotalEarnings(marketState.TotalEarnings);

                    marketState.UpdateCurrentRating(marketState.CurrentRating);
                }




                WeeklyReport report = new WeeklyReport
                {

                    WeekStartDate = DateTime.Now.AddDays(i),
                    CustomerCount = marketState.CustomerCount,
                    TotalEarnings = market.Budged,
                    DiscardedVegetablesCount = marketState.DiscardedVegetablesCount,
                    CurrentRating = marketState.CurrentRating
                };
                marketState.WeeklyReports.Add(report);
            }

        }





        public void SaveWeeklyReportsToFile(string filePath)
        {
            try
            {
                string jsonString = JsonSerializer.Serialize(marketState.WeeklyReports, options: new JsonSerializerOptions() { WriteIndented = true });
                File.WriteAllText(filePath, jsonString);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Diqqet , xeta var : {ex.Message}");
            }
        }



        public void PrintWeeklyReports()
        {
            foreach (var report in marketState.WeeklyReports)
            {
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine($"Week Start Date: {report.WeekStartDate}");
                Console.ForegroundColor = ConsoleColor.White;

                Console.WriteLine($"Customer Count: {report.CustomerCount}");
                Console.WriteLine($"Discarded Vegetables Count: {report.DiscardedVegetablesCount}");
                Console.WriteLine($"Current Rating: {report.CurrentRating}");
                Console.WriteLine();
            }
        }


        public void AddMarketState(MarketState newMarketState)
        {
            marketState = newMarketState;
        }




    }
}




