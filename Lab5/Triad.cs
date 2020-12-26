using System;
using System.Collections.Generic;
using System.Text;

namespace Lab5
{
    public abstract class Triad
    {
        private readonly int _maxA;
        private readonly int _maxB;
        private readonly int _maxC;
        private int _a,_b,_c;
        

        protected Triad(int maxA, int maxB, int maxC, int a, int b, int c)
        {
            this._maxA = maxA;
            this._maxB = maxB;
            this._maxC = maxC;
            this._a = a;
            this._b = b;
            this._c = c;
        }

        public int IncrementAndGet(TriadNumber number)
        {
            Change(number, 1);
            return Get(number);
        }

        public int DecrementAndGet(TriadNumber number)
        {
            Change(number, -1);
            return Get(number);
        }

        public int GetAndIncrement(TriadNumber number)
        {
            int temp = Get(number);
            Change(number, 1);
            return temp;
        }

        public int GetAndDecrement(TriadNumber number)
        {
            int temp = Get(number);
            Change(number, 1);
            return temp;
        }

        public int Get(TriadNumber number)
        {
            return number switch
            {
                TriadNumber.FIRST => _a,
                TriadNumber.SECOND => _b,
                TriadNumber.THIRD => _c,
                _ => throw new ArgumentOutOfRangeException(nameof(number), number, "Invalid triad number")
            };
        }

        private void Change(TriadNumber number, int x)
        {
            switch (number)
            {
                case TriadNumber.FIRST:
                    _a += x;
                    break;
                case TriadNumber.SECOND:
                    _b += x;
                    break;
                case TriadNumber.THIRD:
                    _c += x;
                    break;
                default:
                    throw new ArgumentOutOfRangeException(nameof(number), number, "Invalid triad number");
            }
        }

        protected void Set(TriadNumber number, int x)
        {
            switch (number)
            {
                case TriadNumber.FIRST:
                    _a = x;
                    break;
                case TriadNumber.SECOND:
                    _b = x;
                    break;
                case TriadNumber.THIRD:
                    _c = x;
                    break;
                default:
                    throw new ArgumentOutOfRangeException(nameof(number), number, "Invalid triad number");
            }
        }

        protected virtual void SpecialRound(SpecialRoundType specialRound)
        { 
        }

        protected void Round()
        {
            if (_a > _maxA)
            {
                SpecialRound(SpecialRoundType.INCREMENT);
                _b++;
                _a = 0;
                SpecialRound(SpecialRoundType.NULL_INCREMENT);
            }

            if (_b > _maxB)
            {
                SpecialRound(SpecialRoundType.INCREMENT);
                _c++;
                _b = 0;
                SpecialRound(SpecialRoundType.NULL_INCREMENT);
            }

            if (_c > _maxC)
            {
                SpecialRound(SpecialRoundType.INCREMENT);
                _c = 0;
                SpecialRound(SpecialRoundType.NULL_INCREMENT);
            }


            SpecialRound( SpecialRoundType.NULL_DECREMENT);
            if (_a < 0)
            {
                _b--;
                _a = _maxA;
                SpecialRound(SpecialRoundType.DECREMENT);
            }

            SpecialRound(SpecialRoundType.NULL_DECREMENT);
            if (_b < 0)
            {
                _c--;
                _b = _maxB;
                SpecialRound(SpecialRoundType.DECREMENT);
            }
            SpecialRound(SpecialRoundType.NULL_DECREMENT);
            if (_c < 0)
            {
                SpecialRound(SpecialRoundType.DECREMENT);
                _c = _maxC;
            }

        }

    }
}
