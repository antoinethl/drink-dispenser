using System;
using System.Collections.Generic;
using System.Linq;

namespace Design_Pattern_TD4_3
{
    class Program
    {
 
        private static void Init()
        {
            // MOCK OBJECTS FOR THE EXERCISE

            Coca.GetInstance().Price = 1.35;
            Cafe.GetInstance().Price = 2;
            IceTea.GetInstance().Price = 1.50;
            Sprite.GetInstance().Price = 1.60;

            Dictionary<DrinkCode, int> d1 = new Dictionary<DrinkCode, int>
            {
                { new DrinkCode(Coca.GetInstance()), 4 },
                { new DrinkCode(IceTea.GetInstance()), 3 },
                { new DrinkCode(Sprite.GetInstance()), 7 }
            };

            Dictionary<DrinkCode, int> d2 = new Dictionary<DrinkCode, int>
            {
                { new DrinkCode(Coca.GetInstance()), 5 },
                { new DrinkCode(Cafe.GetInstance()), 4 },
                { new DrinkCode(IceTea.GetInstance()), 8 }
            };

            Dictionary<DrinkCode, int> d3 = new Dictionary<DrinkCode, int>
            {
                { new DrinkCode(Cafe.GetInstance()), 3 },
                { new DrinkCode(IceTea.GetInstance()), 8 },
                { new DrinkCode(Sprite.GetInstance()), 2 }
            };

            Dictionary<DrinkCode, int> d4 = new Dictionary<DrinkCode, int>
            {
                { new DrinkCode(Coca.GetInstance()), 7 },
                { new DrinkCode(Cafe.GetInstance()), 3 },
                { new DrinkCode(Sprite.GetInstance()), 6 }
            };

            Distributor.Stock.Add(d1);
            Distributor.Stock.Add(d2);
            Distributor.Stock.Add(d3);
            Distributor.Stock.Add(d4);
        }

        static void Main(string[] args)
        {
            Init();

            Distributor.Disp.Run(); 
        }
    }
}