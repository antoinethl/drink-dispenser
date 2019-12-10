using System;
using System.Collections.Generic;
using System.Text;

namespace Design_Pattern_TD4_3
{
    class Sprite : Drink
    {
        // SINGLETON 

        private Sprite() { }
        private static Sprite _sprite;

        public static Sprite GetInstance() { if (_sprite == null) _sprite = new Sprite(); return _sprite; }
    }
}
