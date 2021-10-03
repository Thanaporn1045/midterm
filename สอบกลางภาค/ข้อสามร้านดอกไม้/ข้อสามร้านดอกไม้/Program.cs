using System;
using System.Collections.Generic;

namespace ข้อสามร้านดอกไม้
{
    class Program
    {
        static void Main(string[] args)
        {
            string decide = "y";
            string selectFlower;
            FlowerStore flowerStore = new FlowerStore();
            SelectNumFlower(flowerStore, out selectFlower, decide);

        }
        static void SelectNumFlower(FlowerStore flowerStore ,out string selectFlower, string decide)
        {

            do
            {
                Console.WriteLine("Select number for buy flower :");
                foreach (string i in flowerStore.flowerList)
                {
                    Console.Write((flowerStore.flowerList.IndexOf(i) + 1) + " ");
                    Console.WriteLine(i);
                }
                selectFlower = Console.ReadLine();
                AddFlower(selectFlower,flowerStore);

                decide = StopProcress(decide,flowerStore);
        }while(decide != "exit");
        }
        static void AddFlower(string selectFlower, FlowerStore flowerStore)
        {
            switch (selectFlower)
            {
                case "1":
                    flowerStore.addToCart(flowerStore.flowerList[0]);
                    Console.WriteLine("Added " + flowerStore.flowerList[0]);
                    break;
                case "2":
                    flowerStore.addToCart(flowerStore.flowerList[1]);
                    Console.WriteLine("Added " + flowerStore.flowerList[1]);
                    break;
                default:
                    Console.WriteLine("Not Added to cart. found select number of flower");
                    break;
            }
        }
        static string StopProcress(string decide, FlowerStore flowerStore) 
        {
            Console.WriteLine("You can stop this progress ? exit for >> exit << progress and press any key for continue");
            decide = Console.ReadLine();
            if (decide == "exit")
            {
                Console.Write("Current my cart");
                flowerStore.showCart();
            }
            return decide;
        }
}
}
