using System;
using System.Collections.Generic;
using System.Text;

namespace Design_Pattern_TD4_3
{
    public abstract class Drink
    {
        // Factory Pattern so all the drinks possess the same interface

        private double price;

        public double Price { get => price; set => SetPrice(value); }

        private void SetPrice(double value)
        {
            this.price = value;
        }
    }
}
