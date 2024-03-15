using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace Final
{
    public class Customer
    {
        public string Name { get; set; }
        public List<Vegetable> ShoppingList { get; set; }

        public double CustomerBudget { get; set; }
        public Customer(string name)
        {
            Name = name;
            ShoppingList = new List<Vegetable>();
            CustomerBudget = 0;
        }

        

        public void AddToShoppingList(Vegetable vegetable)
        {
            ShoppingList.Add(vegetable);

        }

        public void RemoveFromShoppingList(Vegetable vegetable)
        {

            ShoppingList.Remove(vegetable);

        }

        public void CompleteShopping(MarketState marketState, int custom)
        {
            marketState.UpdateCustomerCount(custom);


        } //diqqet et sehv ola biler bu funksiyada
    }
}
