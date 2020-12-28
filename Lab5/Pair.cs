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
            _key = key;
            _value = value;
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
            _key = key;
        }

        public void SetValue(Triad value)
        {
            _value = value;
        }
    }
}
