namespace Final
{
    //final project 

    public class Program
    {
        private static void Main(string[] args)
        {
            MarketState safmarketState = new MarketState();
            Market saf = new Market();

            //default yaratdiqlarim
            Vegetable_Stand tomatoStand = new Vegetable_Stand("pomidor");
            Vegetable tomato = new Vegetable("pomidor", 100, 3.0);
            tomatoStand.Add_Vegetable(tomato);
            saf.Stands.Add(tomatoStand);


            Vegetable_Stand cucumberStand = new Vegetable_Stand("xiyar");
            Vegetable cucumber = new Vegetable("xiyar", 100, 4.0);
            cucumberStand.Add_Vegetable(cucumber);
            saf.Stands.Add(cucumberStand);


            Vegetable_Stand appleStand = new Vegetable_Stand("alma");
            Vegetable apple = new Vegetable("alma", 100, 5.0);
            appleStand.Add_Vegetable(apple);
            saf.Stands.Add(appleStand);

            Vegetable_Stand pearStand = new Vegetable_Stand("armud");
            Vegetable pear = new Vegetable("armud", 100, 2.0);
            pearStand.Add_Vegetable(pear);
            saf.Stands.Add(pearStand);


            Vegetable_Stand pomegranadeStand = new Vegetable_Stand("nar");
            Vegetable pomegranade = new Vegetable("nar", 100, 1.0);
            pomegranadeStand.Add_Vegetable(pomegranade);
            saf.Stands.Add(pomegranadeStand);





            //yeni meyve standi elave etmek ucun 
            //Vegetable grape = new Vegetable("Uzum", 100, 6.0);
            //saf.Take_New_Vegetable(grape);

            //************************************************************
            //************************************************************
            //************************************************************
            //************************************************************



            //Mushterilerin yaradilmasi ve istehlakci klasina elavesi ve mushterilerin mal almasi prosesi 






            Consumer consumer = new Consumer(saf);

            Random random = new Random();

            int totalDays = 2; 
            int minCustomersPerDay = 1;
            int maxCustomersPerDay = 1; 

            for (int day = 1; day <= totalDays; day++)
            {
                int customersPerDay = random.Next(minCustomersPerDay, maxCustomersPerDay + 1);
                Console.WriteLine($"Day {day}, Customers: {customersPerDay}");

                for (int customerIndex = 1; customerIndex <= customersPerDay; customerIndex++)
                {
                    Customer customer = new Customer($"Customer {customerIndex}");

                    customer.AddToShoppingList(pomegranade);
                    customer.AddToShoppingList(pear);
                    customer.AddToShoppingList(tomato);
                    customer.AddToShoppingList(cucumber);
                    customer.AddToShoppingList(apple);

                    Vegetable vegetable = consumer.GetRandomVegetable();
                    double quantity = consumer.GetRandomQuantity();
                    customer.AddToShoppingList(vegetable);

                    consumer.AddCustomer(customer);

                }

                consumer.ProcessCustomers();
                safmarketState.UpdateCustomerCount(customersPerDay);
                
                
            }

            #region Meyvelerin fresh durumu

            //**********************************************************
            //**********************************************************
            //**********************************************************
            //**********************************************************


            //saf.Show_All_Stands();

            //saf.Show_All_Stands();

            //TimeSpan waitTime = TimeSpan.FromSeconds(5);


            //saf.Spoiling_Timer();

            //saf.ShowVegetableStatus();
            //Console.WriteLine("5 saniye gozleyek ... ");
            //Thread.Sleep(waitTime);
            //Console.WriteLine("Vaxt tamamlandi ");

            //saf.ShowVegetableStatus();
            //Console.WriteLine("5 saniye gozleyek ... ");
            //Thread.Sleep(waitTime);
            //Console.WriteLine("Vaxt tamamlandi ");

            //saf.ShowVegetableStatus();
            //Console.WriteLine("5 saniye gozleyek ... ");
            //Thread.Sleep(waitTime);
            //Console.WriteLine("Vaxt tamamlandi ");

            //saf.ShowVegetableStatus();
            //Console.WriteLine("5 saniye gozleyek ... ");
            //Thread.Sleep(waitTime);
            //Console.WriteLine("Vaxt tamamlandi ");

            //saf.ShowVegetableStatus();
            //saf.ShowToxicVegetable();

            #endregion

            //saf.Show_All_Stands();


            MarketManager marketmanager = new MarketManager(saf);
            marketmanager.AddMarketState(safmarketState);

            marketmanager.GenerateWeeklyReport();
            Console.WriteLine("Weekly Reports");
            marketmanager.PrintWeeklyReports();


            //indi market durumunu json olaraq seriallashdiracam
            string marketStatePath = "safmarket.json";
            marketmanager.SerializeMarketState(marketStatePath);
            Console.WriteLine($"Marketin durumu JSON ile seriallashdirildi");

            //burada desialize edirem
            marketmanager.DeserializeMarketState(marketStatePath);
            Console.WriteLine();

            //oxuma 
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine($"Marketin durumu JSON ile oxundu : ");
            Console.ForegroundColor = ConsoleColor.White;

            Console.WriteLine($"                            Customer Count      :{marketmanager.marketState.CustomerCount}");
            Console.WriteLine($"                            Total Earning       :{saf.CompletePurchase(totalDays,safmarketState} ");
            Console.WriteLine($"                            Discarded Vegetable :{marketmanager.marketState.DiscardedVegetablesCount}");
            Console.WriteLine($"                            Current Rating      :{marketmanager.marketState.CurrentRating}");



            //Heftelik melumatlari JSON ile yadda saxlamaq
            string weeklyReportsFilePath = "weeklyReport.json";
            marketmanager.SaveWeeklyReportsToFile(weeklyReportsFilePath);
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine($"Heftelik melumatlar JSON ile file - a yazildi ve yadda saxlanildi  ");
            Console.ForegroundColor = ConsoleColor.White;

        }
    }

}

// kodda deyihsilmeli olanalar 


//QLOBAL PROBLME JSON DUSHMEMESIDIR  BEZIDEYISHIKLIKLERIN ... 











