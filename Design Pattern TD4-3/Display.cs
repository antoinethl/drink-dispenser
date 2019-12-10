using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Design_Pattern_TD4_3
{
    class Display
    {
        public static void ShowDrinks(List<Dictionary<DrinkCode, int>> stock)
        {
            foreach (Dictionary<DrinkCode, int> row in stock)
            {
                Console.WriteLine("-------------------------------------------------------------------------------------------------------------------------------------------------");
                foreach (KeyValuePair<DrinkCode, int> k in row)
                {
                    Console.Write("|" + k.Key.Code + "| " + k.Key.drink.GetType().Name + " : " + k.Value + " left, price: " + k.Key.drink.Price + " euros\t\t");
                }
                Console.WriteLine("|");
            }
            Console.WriteLine("-------------------------------------------------------------------------------------------------------------------------------------------------");
            Console.WriteLine();
        }

        public static void MoneyInserted(MoneyCollector m)
        {
            Console.WriteLine("You already inserted " + m.TotalMoneyInDouble + " euros :");
            Console.WriteLine(m.Show());
        }

        public static void Insert(MoneyCollector m) // Method which ask the user what types of coins he wants to insert
        {
            string choice;

            Console.WriteLine("Which coin do you want to insert ?");
            Console.WriteLine("\t1 : 2 euros");
            Console.WriteLine("\t2 : 1 euro");
            Console.WriteLine("\t3 : 50 cents");
            Console.WriteLine("\t4 : 20 cents");
            Console.WriteLine("\t5 : 10 cents");
            Console.WriteLine("\t6 : 5 cents");
            Console.WriteLine("\t7 : 2 cents");
            Console.WriteLine("\t8 : 1 cent");
            Console.WriteLine("\t9 : Exit");

            do
            {
                MoneyInserted(m);
                choice = Console.ReadLine();
                switch (choice)
                {
                    case "1":
                        m.Insert(Money.EURO_2);
                        break;
                    case "2":
                        m.Insert(Money.EURO_1);
                        break;
                    case "3":
                        m.Insert(Money.CENT_50);
                        break;
                    case "4":
                        m.Insert(Money.CENT_20);
                        break;
                    case "5":
                        m.Insert(Money.CENT_10);
                        break;
                    case "6":
                        m.Insert(Money.CENT_5);
                        break;
                    case "7":
                        m.Insert(Money.CENT_2);
                        break;
                    case "8":
                        m.Insert(Money.CENT_1);
                        break;
                }
            } while (choice != "9");
        }

        public void Run()
        {
            bool test = false;
            bool leave = false;
            int drinkPrice = 0;

            do
            {
                ShowDrinks(Distributor.Stock);
                Insert(Distributor.Collector);
                ShowDrinks(Distributor.Stock);

                do
                {
                    Console.WriteLine("Choose your drink using the code.");
                    string code = Console.ReadLine();
                    DrinkCode drinkCode = new DrinkCode();

                    // We use a predicate + delegates to find the DrinkCode having the code corresponding to the one entered by the user

                    bool predicate(DrinkCode x) => x.Code.ToString() == code;

                    foreach (Dictionary<DrinkCode, int> row in Distributor.Stock)
                    {
                        if (Array.Find(row.Keys.ToArray(), predicate) != null)
                        {
                            drinkCode = Array.Find(row.Keys.ToArray(), predicate);
                        }
                    }

                    // We also use delegates

                    Dictionary<DrinkCode, int> rowDrink = Distributor.Stock.Find(x => x.Keys.Contains(drinkCode));

                    if (drinkCode.drink == null) // If the code doesn't exist
                    {
                        Console.WriteLine("Wrong code");
                    }
                    else if (rowDrink[drinkCode] == 0) // If there is no more stock of a drink
                    {
                        Console.WriteLine("No more stock for this drink, try an other\n");
                    }
                    else
                    {
                        while (Distributor.Collector.TotalMoneyInDouble < drinkCode.drink.Price) // If there is no enough moner inserted
                        {
                            Console.WriteLine("You inserted " + Distributor.Collector.TotalMoneyInDouble + " euros and the price for this product is " + drinkCode.drink.Price + " euros, you have to insert more !\n");
                            Insert(Distributor.Collector);
                        }

                        Console.WriteLine("You have received 1 " + drinkCode.drink.GetType().Name + "\n");
                        rowDrink[drinkCode]--; // -1 drink
                        drinkPrice = Convert.ToInt32(drinkCode.drink.Price * 100); // As I said, we used both TotalMoney in Int and in Double
                        test = true;
                    }
                } while (!test);

                Dictionary<Money, int> moneyReturned = Distributor.Collector.GetChange(drinkPrice);
                ShowMoneyReturned(moneyReturned, drinkPrice);
                Distributor.ResetMoneyCollector();

                Console.WriteLine("\nLeave ?");
                Console.WriteLine("\t1. Yes");
                Console.WriteLine("\t2. No");

                leave = Console.ReadLine() == "1";
                
            } while (!leave);
        }

        public static void ShowMoneyReturned(Dictionary<Money,int> change, int drinkPrice)
        {
            double money = (double)(Distributor.Collector.TotalMoney - drinkPrice) / 100;
            Console.WriteLine("The machine gave you back " + money + " :");
            foreach (KeyValuePair<Money,int> coins in change)
            {
                string test = CoinInString(coins.Key);
                Console.WriteLine("\t- " + coins.Value + " time " + test);

            }
        }

        public static string CoinInString(Money coin)
        {
            string coinInString = "";
            switch (coin)
            {
                case Money.EURO_2:
                    coinInString = "2 euros";
                    break;
                case Money.EURO_1:
                    coinInString = "1 euro";
                    break;
                case Money.CENT_50:
                    coinInString = "50 cents";
                    break;
                case Money.CENT_20:
                    coinInString = "20 cents";
                    break;
                case Money.CENT_10:
                    coinInString = "10 cents";
                    break;
                case Money.CENT_5:
                    coinInString = "5 cents";
                    break;
                case Money.CENT_2:
                    coinInString = "2 cents";
                    break;
                case Money.CENT_1:
                    coinInString = "1 cent";
                    break;
            }
            return coinInString;
        }
    }
}
