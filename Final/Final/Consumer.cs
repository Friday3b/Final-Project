using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Final
{
    public class Consumer : Market
    {
        public Customer Customer { get; set; }
        public MarketState marketState = new MarketState();
        private Queue<Customer> customers;
        public Market market;
        private Random random;

        public Consumer(Market market)
        {
            customers = new Queue<Customer>();
            this.market = market;
            random = new Random();
        }

        public void AddCustomer(Customer customer)
        {
            customers.Enqueue(customer);
        }


        //for (int i = 1; i <= 3; i++)
        //{
        //    Customer customer = new Customer($"Customer {i}");
        //    for (int j = 0; j < 1; j++)
        //    {
        //        string vegetable = consumer.GetRandomVegetable();
        //        double quantity = consumer.GetRandomQuantity();
        //        customer.AddToShoppingList(apple);
        //        customer.AddToShoppingList(grape);
        //        customer.AddToShoppingList(pomegranade);
        //        customer.AddToShoppingList(pear);
        //        customer.AddToShoppingList(tomato);
        //        customer.AddToShoppingList(cucumber);



        public void ProcessCustomersFor7Days()
        {
            Thread.Sleep(1000);
            for (int day = 1; day <= 7; day++)
            {
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine($"Day {day}:");
                Console.ForegroundColor = ConsoleColor.White;

                ProcessCustomers();
                Console.WriteLine();
            }
        }


        public void ProcessCustomers()
        {
            while (customers.Count > 0)
            {



                var customer = customers.Dequeue();
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine("_________________________________________________");
                Console.WriteLine($"{customer.Name} marketden erzaq alir   ");
                Console.ForegroundColor = ConsoleColor.White;

                foreach (var vegetable in customer.ShoppingList)
                {
                    market.BuyVegetable(vegetable, GetRandomQuantity());
                    //marketState.UpdateCustomerCount();


                    //BURADA COMPLETE SHOPPING DE UPTADE CUSTOMER COUNT EDIR 
                    Thread.Sleep(1000);


                }
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine($"{customer.Name} - in bazarliqi bitdi ");
                Console.ForegroundColor = ConsoleColor.White;
                Console.WriteLine($"Total Price : {market.Budged} azn ");
                marketState.UpdateTotalEarnings(market.Budged);


            }
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("_________________________________________________");
            Console.ForegroundColor = ConsoleColor.White;

        }



        public Vegetable GetRandomVegetable()
        {
            string[] vegetables = { "pomidor", "xiyar", "alma", "nar", "armud" };
            string randomVegetableName = vegetables[random.Next(vegetables.Length)];


            //bir vegetable numunesi yaradiriq random olaraq

            double weight = GetRandomQuantity();
            double price = GenerateRandomPrice();
            Vegetable randomVegetable = new Vegetable(randomVegetableName, weight, price);

            return randomVegetable;


        }

        public double GetRandomQuantity()
        {
            return random.Next(1, 30); //mushteriler 1 ve 7 kq arasinda mehsul ala bilerler 

        }

        public double GenerateRandomPrice()
        {
            Random random = new Random();
            return (double)(random.NextDouble() * (10 - 1) + 1);
        }

    }
}
