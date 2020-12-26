using System;
using System.Collections.Generic;
using System.Text;

namespace Lab5
{
    class Memories
    {
        private readonly Pair[] _pairs;
        private readonly int _maxSize;

        public Memories(int size)
        {
            _maxSize = size;
            _pairs = new Pair[size];
        }

        public Pair GetPair(int index)
        {
            return _pairs[index];
        }

        public void SetPair(int index, Pair pair)
        {
            _pairs[index] = pair;
        }

        public void RemovePair(int index)
        {
            _pairs[index] = null;
        }

        public int GetSize()
        {
            return _maxSize;
        }
    }
}
