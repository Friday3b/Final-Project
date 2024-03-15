using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Timers;

namespace Final
{
    public class Market
    {

        MarketState marketState { get; set; }
        public List<Vegetable_Stand>? Stands { get; set; }
        private System.Timers.Timer timer;
        public int Rating { get; set; }
        public double Budged { get; set; }


        public Market()
        {
            Stands = new List<Vegetable_Stand>();
            Rating = 5;
            Budged = 0;
        }

        public void Spoiling_Timer()
        {
            timer = new System.Timers.Timer(5000);
            timer.Elapsed += SpoilVegetable;
            timer.AutoReset = true;
            timer.Enabled = true;


        }

        public void SpoilVegetable(object sender, System.Timers.ElapsedEventArgs elps)
        {
            foreach (var stand in Stands)
            {
                foreach (var vegetable in stand.vegetables)
                {
                    vegetable.Spoil(sender, elps);

                }

                List<Vegetable> toBeRemoved = new List<Vegetable>();
                foreach (var vegetable in stand.vegetables)
                {
                    if (vegetable.Condition == Vegetable.State.Toxic)
                    {
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine($"{vegetable.Name} curumush hala geldi ,atilir");
                        Console.ForegroundColor = ConsoleColor.White;

                        toBeRemoved.Add(vegetable);
                    }
                }

            }
        }
        //*******************************************
        public void ShowVegetableStatus()
        {

            //Console.Clear();
            foreach (var stand in Stands)
            {
                Console.WriteLine($"Stand: {stand.Name}");

                foreach (var vegetable in stand.vegetables)
                {
                    Console.ForegroundColor = ConsoleColor.Yellow;
                    Console.WriteLine($"{vegetable.Name} durumu: {vegetable.Condition}");
                    Console.ForegroundColor = ConsoleColor.White;

                }
                Console.WriteLine();
            }
        }















        //********************************************
        //public void Show_All_Stands()
        //{
        //    foreach (var stand in Stands)
        //    {


        //        if (stand is null)
        //        {
        //            Console.ForegroundColor = ConsoleColor.Red;
        //            throw new Exception("Her hansisa stand yoxdur . excp");
        //            Console.ForegroundColor = ConsoleColor.White;

        //        }
        //        else
        //        {
        //            Console.WriteLine();
        //            Console.ForegroundColor = ConsoleColor.Yellow;
        //            Console.WriteLine($"stand :{stand.Name} ");  // bura eyni zamanda vegetable larin ceki si ve qiymetini de ela ve elemeliyem ....!!!!!!
        //            Console.ForegroundColor = ConsoleColor.White;
        //        }
        //    }
        //    Thread.Sleep(2000);
        //    Console.Clear();
        //}

        public void Show_All_Stands()
        {
            foreach (var stand in Stands)
            {
                if (stand is null)
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    throw new Exception("Stand tapilmadi");
                    Console.ForegroundColor = ConsoleColor.White;
                }
                else
                {


                    Console.WriteLine();
                    Console.ForegroundColor = ConsoleColor.Yellow;
                    Console.WriteLine($"Stand: {stand.Name}");

                    double totalWeight = 0;
                    double totalPrice = 0;

                    foreach (var vegetable in stand.vegetables)
                    {


                        totalWeight += vegetable.Weight;
                        totalPrice += vegetable.Price; // 1 kilogram meyvenin qiymeti
                    }

                    Console.WriteLine($"Toplam meyve miqdari: {totalWeight} kg");
                    Console.WriteLine($"1 kq meyvenin qiymeti: {totalPrice} manat");
                    Console.ForegroundColor = ConsoleColor.White;
                }
            }
            Thread.Sleep(20000);
            Console.Clear();
        }










        public void Take_New_Vegetable(Vegetable newVegetable)
        {
            bool foundMatchingStand = false;

            foreach (var stand in Stands)
            {
                if (stand.Name == newVegetable.Name)
                {
                    stand.Add_Vegetable(newVegetable);
                    foundMatchingStand = true;
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.WriteLine($"*{newVegetable} standi tapildi ve ora elave olundu*");
                    Console.ForegroundColor = ConsoleColor.White;

                    break;
                }
            }

            if (!foundMatchingStand)
            {


                Vegetable_Stand newStand = Create_New_Stand(newVegetable.Name);

                if (newStand is null)
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    throw new Exception("yeni stand yaradilmadi  - excp.");
                    Console.ForegroundColor = ConsoleColor.White;

                }

                newStand.Add_Vegetable(newVegetable);
                Stands.Add(newStand);
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine($"*{newVegetable.Name} standi yaradildi ve ora elave edildi*");
                Console.ForegroundColor = ConsoleColor.White;

            }

        }
        #region Lazimsiz hisse

        //****************************************************************************************************
        //****************************************************************************************************
        //****************************************************************************************************

        //Vegetable_Stand suitablestand = find_mostsuitable_stand(newVegetable);

        //    if (suitablestand == null)
        //    {
        //        suitablestand = Create_New_Stand();
        //        Stands.Add(suitablestand);
        //    }

        //    suitablestand.Add_Vegetable(newVegetable);
        //}


        //public void Take_New_Vegetable(Vegetable newVegetable)
        //{
        //    Vegetable_Stand suitablestand = find_mostsuitable_stand(newVegetable);


        //    if (suitablestand == null)
        //    {
        //        suitablestand = Create_New_Stand();

        //        Stands.Add(suitablestand);
        //    } //teze stand markete elave olunur burda // diqqet et !!! 

        //    suitablestand.Add_Vegetable(newVegetable);

        //    suitablestand.Add_Vegetable(newVegetable);

        //}



        //public Vegetable_Stand find_mostsuitable_stand(Vegetable vegetable)
        //{
        //    foreach (var stand in Stands)
        //    {
        //        foreach (var T in stand.vegetables)
        //        {
        //            if (T.Name == vegetable.Name)
        //            {
        //                Console.WriteLine("Uygun stand bulundu ve oraya eklendi: " + T.Name);
        //                return stand;
        //            }
        //        }
        //    }

        //    // Eğer uygun stand bulunamazsa yeni bir stand oluştur ve onu geri döndür
        //    Console.WriteLine("Yeni stand oluşturuldu ve oraya eklendi.");
        //    Vegetable_Stand newStand = Create_New_Stand();
        //    Stands.Add(newStand);
        //    return newStand;
        //}

        #endregion

        public Vegetable_Stand Create_New_Stand(string name)
        {


            Vegetable_Stand newStand = new Vegetable_Stand();
            newStand.Name = name;


            if (string.IsNullOrEmpty(name))
            {
                Console.ForegroundColor = ConsoleColor.Red;
                throw new Exception("Yeni stand ucun ad bosh ola bilmez , lutfen ad daxil edin .");
                Console.ForegroundColor = ConsoleColor.White;

            }


            return newStand;
        }


        public void BuyVegetable(Vegetable vegetable, double kilos)
        {

            double totalPrice = 0;

            foreach (var stand in Stands)
            {
                foreach (var veg in stand.vegetables)
                {

                    if (veg.Name == vegetable.Name)
                    {
                        if (veg.Weight >= kilos)
                        {

                            double price = kilos * veg.Price;
                            totalPrice += price;
                            Console.WriteLine($"Mushteri {kilos} kq {veg.Name} aldi . Toplam mebleg: {price} azn");


                            if (veg.Condition == Vegetable.State.Toxic)
                            {
                                marketState.UpdateDiscardedVegetablesCount(veg);


                                Console.ForegroundColor = ConsoleColor.Red;
                                Console.WriteLine($"Bildirish : {veg.Name}meyvesi curuk cixdi");
                                Console.ForegroundColor = ConsoleColor.White;

                                veg.Rating -= 1;
                                Console.ForegroundColor = ConsoleColor.Red;
                                Console.WriteLine($"{veg.Name}meyvesinin reytinqi dushdu ");
                                Console.ForegroundColor = ConsoleColor.White;

                                Rating -= 1;
                                Console.ForegroundColor = ConsoleColor.Red;
                                Console.WriteLine($" Marketin de reytinqi dushdu : {Rating} ");
                                Console.ForegroundColor = ConsoleColor.White;

                            }
                            veg.Weight -= kilos;
                            Budged += price;
                            return;


                        }
                        else
                        {
                            Console.ForegroundColor = ConsoleColor.Red;
                            Console.WriteLine($"{veg.Name} stokda lazimi miqdarda yoxdur");
                            Console.ForegroundColor = ConsoleColor.White;

                        }


                        return;
                    }

                }

            }
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine($"{vegetable.Name} adinda meyve tapilmadi");
            Console.ForegroundColor = ConsoleColor.White;



        }



        private void SpoilVegetable(Vegetable veg, string name)
        {
            throw new NotImplementedException();
        }

        public void ShowToxicVegetable()
        {
            foreach (var stand in Stands)
            {
                foreach (var vegetable in stand.vegetables)
                {

                    if (vegetable.Condition == Vegetable.State.Toxic)
                    {

                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine($"{vegetable.Name} toxic veziyyetdedir , yararsizdir ");
                        Console.ForegroundColor = ConsoleColor.White;

                        BuyVegetable(vegetable, 10);
                        Take_New_Vegetable(vegetable);
                    }


                }
            }



        }



        public bool CheckIfToxic(string vegetableName)
        {

            bool toksiktapildi = false;
            foreach (var stand in Stands)
            {
                foreach (var vegetable in stand.vegetables)
                {
                    if (vegetable.Name == vegetableName && vegetable.Condition == Vegetable.State.Toxic)
                    {
                        //Console.ForegroundColor = ConsoleColor.Red;
                        //Console.WriteLine($"{vegetable.Name} toksikdir ");
                        //Console.ForegroundColor = ConsoleColor.White;
                        toksiktapildi = true;
                        break;

                    }


                }
                if (toksiktapildi)
                    break;
            }

            return toksiktapildi;
            //Console.ForegroundColor = ConsoleColor.Green;
            //Console.WriteLine($"{vegetableName} toksik deyil ");
            //Console.ForegroundColor = ConsoleColor.White;

        }

        public void CompletePurchase(double amount, MarketState marketState)
        {
            marketState.UpdateTotalEarnings(amount);
        }
        //public void DiscardVegetable(MarketState marketState)
        //{
        //    marketState.IncreaseDiscardedVegetablesCount();
        //}
        public void UpdateRating(int rating, MarketState marketState)
        {
            marketState.UpdateCurrentRating(rating);
        }

    }
}
