using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Timers;

namespace Final
{
    public class Vegetable
    {
        public State Condition { get; set; }  //durum
        public string Name { get; set; }
        public double Weight { get; set; }
        public int Rating { get; set; }
        public double Price { get; set; }


        public Vegetable(string name, double weight, double price)
        {
            this.Name = name;
            this.Condition = State.Fresh;
            this.Weight = weight;
            this.Rating = 5;
            this.Price = price;
        }



        public override string ToString()
        {
            return Name;
        }
        //**************************************

        public enum State//hal
        {
            Fresh,
            Normal,
            Rotten,
            Toxic
        }
        //event
        public void Spoil(object sender, ElapsedEventArgs elps)
        {
            if (Condition < State.Toxic)
            {
                Condition++;
                Console.WriteLine($"{Name} {Condition}");
            }
            else
            {
                Rating -= 1;
                Console.WriteLine($"{Name} toksik oldugu ucun reytinqi dushdu {Rating}");

            }

        }
        //yeni terevez gelmesi         
    }
}
