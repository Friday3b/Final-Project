using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Final
{
    public class Vegetable_Stand
    {
        public Stack<Vegetable> vegetables;

        public string Name { get; set; }
        public int Rating { get; set; }
        public Vegetable_Stand(string name) => Name = name;

        public override string ToString()
        {
            return Name;
        }

        public Vegetable_Stand()
        {
            vegetables = new Stack<Vegetable>();
        }

        public void Add_Vegetable(Vegetable vegetable)
        {
            if (vegetables == null)
                vegetables = new Stack<Vegetable>();

            vegetables.Push(vegetable);
        }


        //LAZIMSIZDIR AMA QALSIN HELE 
        public Vegetable Buy_Vegetable()
        {
            if (vegetables != null && vegetables.Count > 0)
                return vegetables.Pop();
            else
            {
                Console.WriteLine("Stentde meyve yoxdur ");
                return null;
            }
        }
    }
}
