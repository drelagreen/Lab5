using System;
using System.Collections.Generic;
using System.Text;

namespace Lab5
{
    class Pair
    {
        private Triad _key = null;
        private Triad _value = null;
        
        public Pair() {}

        public Pair(Triad key, Triad value)
        {
            this._key = key;
            this._value = value;
        }

        public Triad GetKey()
        {
            return _key;
        }

        public Triad GetValue()
        {
            return _value;
        }

        public void SetKey(Triad key)
        {
            this._key = key;
        }

        public void SetValue(Triad value)
        {
            this._value = value;
        }
    }
}
