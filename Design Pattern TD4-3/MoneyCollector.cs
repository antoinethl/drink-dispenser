using System;
using System.Collections.Generic;

namespace Design_Pattern_TD4_3
{
    enum Money { EURO_2, EURO_1, CENT_50, CENT_20, CENT_10, CENT_5, CENT_2, CENT_1 };

    class MoneyCollector
    {
        // A class which contains the number of coin for each types, which compute the total money in Int and in Double

        protected int euro2 = 0;
        protected int euro1 = 0;
        protected int cent50 = 0;
        protected int cent20 = 0;
        protected int cent10 = 0;
        protected int cent5 = 0;
        protected int cent2 = 0;
        protected int cent1 = 0;

        protected static int totalMoney;

        // We have the TotalMoney in int (2.50€ = 250) because sometimes, when we use double to compute, there is some problems
        // We also have the TotalMoney in double (we just devide the TotalMoney by 100 and we cast the type using (double))

        public int TotalMoney { get => Total(); }
        public double TotalMoneyInDouble { get => (double)TotalMoney / 100; }

        public MoneyCollector()
        {
        }

        // Compute automatically the TotalMoney (in Int) using the number of each coins inserted so we can't modify it
        private int Total()
        {
            int summ = (euro2 * 200) + (euro1 * 100) + (cent50 * 50) + (cent20 * 20) + (cent10 * 10) + (cent5 * 5) + (cent2 * 2) + (cent1 * 1);
            totalMoney = summ;
            return summ;
        }

        public string Show()
        {
            string l = "";
            if (euro2 != 0) l += "\t- " + euro2 + " time 2 euros\n";
            if (euro1 != 0) l += "\t- " + euro1 + " time 1 euro\n";
            if (cent50 != 0) l += "\t- " + cent50 + " time 50 cents\n";
            if (cent20 != 0) l += "\t- " + cent20 + " time 20 cents\n";
            if (cent10 != 0) l += "\t- " + cent10 + " time 10 cents\n";
            if (cent5 != 0) l += "\t- " + cent5 + " time 5 cents\n";
            if (cent2 != 0) l += "\t- " + cent2 + " time 2 cents\n";
            if (cent1 != 0) l += "\t- " + cent1 + " time 1 cent";
            return l;
        }
        
        public void Insert(Money coin)
        {
            switch(coin)
            {
                case Money.EURO_2:
                    euro2++;
                    break;
                case Money.EURO_1:
                    euro1++;
                    break;
                case Money.CENT_50:
                    cent50++;
                    break;
                case Money.CENT_20:
                    cent20++;
                    break;
                case Money.CENT_10:
                    cent10++;
                    break;
                case Money.CENT_5:
                    cent5++;
                    break;
                case Money.CENT_2:
                    cent2++;
                    break;
                case Money.CENT_1:
                    cent1++;
                    break;
            }
        }

        public Dictionary<Money, int> GetChange(int price)
        {
            int money = TotalMoney - price;
            Dictionary<Money, int> getChange = new Dictionary<Money, int>();

            while (money != 0)
            {
                if (money >= 200)
                {
                    money -= 200;
                    if (getChange.ContainsKey(Money.EURO_2))
                    {
                        getChange[Money.EURO_2]++;
                    }
                    else
                    {
                        getChange.Add(Money.EURO_2, 1);
                    }
                }
                else if (money >= 100)
                {
                    money -= 100;
                    if (getChange.ContainsKey(Money.EURO_1))
                    {
                        getChange[Money.EURO_1]++;
                    }
                    else
                    {
                        getChange.Add(Money.EURO_1, 1);

                    }
                }
                else if (money >= 50)
                {
                    money -= 50;
                    if (getChange.ContainsKey(Money.CENT_50))
                    {
                        getChange[Money.CENT_50]++;
                    }
                    else
                    {
                        getChange.Add(Money.CENT_50, 1);

                    }
                }
                else if (money >= 20)
                {
                    money -= 20;
                    if (getChange.ContainsKey(Money.CENT_20))
                    {
                        getChange[Money.CENT_20]++;
                    }
                    else
                    {
                        getChange.Add(Money.CENT_20, 1);

                    }
                }
                else if (money >= 10)
                {
                    money -= 10;
                    if (getChange.ContainsKey(Money.CENT_10))
                    {
                        getChange[Money.CENT_10]++;
                    }
                    else
                    {
                        getChange.Add(Money.CENT_10, 1);
                    }
                }
                else if (money >= 5)
                {
                    money -= 5;
                    if (getChange.ContainsKey(Money.CENT_5))
                    {
                        getChange[Money.CENT_5]++;
                    }
                    else
                    {
                        getChange.Add(Money.CENT_5, 1);
                    }
                }
                else if (money >= 2)
                {
                    money -= 2;
                    if (getChange.ContainsKey(Money.CENT_2))
                    {
                        getChange[Money.CENT_2]++;
                    }
                    else
                    {
                        getChange.Add(Money.CENT_2, 1);
                    }
                }
                else
                {
                    money -= 1;
                    if (getChange.ContainsKey(Money.CENT_1))
                    {
                        getChange[Money.CENT_1]++;
                    }
                    else
                    {
                        getChange.Add(Money.CENT_1, 1);
                    }
                }
            }
            return getChange;
        }
    }
}