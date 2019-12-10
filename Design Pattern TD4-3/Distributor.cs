using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Design_Pattern_TD4_3
{
    class Distributor
    {

        static List<Dictionary<DrinkCode, int>> stock = new List<Dictionary<DrinkCode, int>>();
        public static List<Dictionary<DrinkCode, int>> Stock { get => stock; set => stock = value; }

        // A money collector
        static MoneyCollector mc = new MoneyCollector();
        public static MoneyCollector Collector { get => mc; }

        public static void ResetMoneyCollector()
        {
            mc = new MoneyCollector();
        }

        // A display
        static Display disp = new Display();
        public static Display Disp { get => disp; }

    }
}
