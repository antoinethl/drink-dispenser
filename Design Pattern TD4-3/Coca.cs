using System;
using System.Collections.Generic;
using System.Text;

namespace Design_Pattern_TD4_3
{
    class Coca : Drink
    {
        // SINGLETON 

        private Coca() { }
        private static Coca _coca;

        public static Coca GetInstance() { if (_coca == null) _coca = new Coca(); return _coca; }
    }
}
