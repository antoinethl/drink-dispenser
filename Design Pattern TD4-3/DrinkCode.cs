using System;
using System.Collections.Generic;
using System.Text;

namespace Design_Pattern_TD4_3
{
    class DrinkCode
    {
        // A class containing a drink and a code that the user will have to enter to choose the drink he wants

        public Drink drink;
        static int iterator = 0;
        public int Code { get; }

        // The iterator is a static member which is incrementing every time we create a new DrinkCode

        public DrinkCode(Drink drink)
        {
            this.drink = drink;
            Code = iterator;
            iterator++;
        }

        public DrinkCode()
        {
        }
    }
}
