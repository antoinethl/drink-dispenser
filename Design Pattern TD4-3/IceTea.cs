using System;
using System.Collections.Generic;
using System.Text;

namespace Design_Pattern_TD4_3
{
    class IceTea : Drink
    {
        // SINGLETON 

        private IceTea() { }
        private static IceTea _icetea;

        static public IceTea GetInstance() { if (_icetea == null) _icetea = new IceTea(); return _icetea; }
    }
}
