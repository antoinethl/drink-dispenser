using System;
using System.Collections.Generic;
using System.Text;

namespace Design_Pattern_TD4_3
{
    class Cafe : Drink
    {
        // SINGLETON 

        private Cafe() { }
        private static Cafe _cafe;

        public static Cafe GetInstance() { if (_cafe == null) _cafe = new Cafe(); return _cafe; }
    }
}
