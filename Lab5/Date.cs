using System;
using System.Collections.Generic;
using System.Text;

namespace Lab5
{
    public class Date : Triad
    {
        public Date(int a, int b, int c) : base(31, 12, 10000, a, b, c)
        {
        }

        protected override void SpecialRound(SpecialRoundType specialRound) 
        {
            int a = Get(TriadNumber.FIRST);
            int b = Get(TriadNumber.SECOND);
            int c = Get(TriadNumber.THIRD);
            switch (specialRound)
            { 
                case (SpecialRoundType.DECREMENT):
                    if (a >= 31)
                        switch (b)
                        {
                            case 2:
                                if (c % 4 == 0 && (c % 100 != 0 || c % 100 == 0))
                                {
                                    a = 29;
                                }
                                else
                                {
                                    a = 28;
                                }
                                break;
                            case 4:
                            case 6:
                            case 9:
                            case 11:
                                a = 30;
                                break;
                        }

                    break;
                case (SpecialRoundType.NULL_DECREMENT):
                    if (a <= 0)
                    {
                        a = -1;
                    }
                    if (b <= 0)
                    {
                        b = -1;
                    }
                    if (c <= 0)
                    {
                        c = -1;
                    }
                    break;
                case (SpecialRoundType.INCREMENT):
                    switch (b)
                    {
                        case 2:
                            if (a == 29 && !(c % 4 == 0 && (c % 100 != 0 || c % 100 == 0)))
                            {
                                a += 1;
                            }
                            break;
                        case 4:
                        case 6:
                        case 9:
                        case 11:
                            if (a == 30)
                            {
                                (a) += 2;
                            }
                            break;
                    }

                    break;
                case (SpecialRoundType.NULL_INCREMENT):
                    if (a <= 0)
                    {
                        a = 1;
                    }
                    if (b <= 0)
                    {
                        b = 1;
                    }
                    if (c <= 0)
                    {
                        c = 1;
                    }

                    break;
                default:
                    throw new ArgumentOutOfRangeException(nameof(specialRound), specialRound, null);
            }

            Set(TriadNumber.FIRST, a);
            Set(TriadNumber.SECOND, b);
            Set(TriadNumber.THIRD, c);
        }
    }
}