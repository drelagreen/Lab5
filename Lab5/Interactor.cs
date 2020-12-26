using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;

namespace Lab5
{
    class Interactor
    {
        private Memories _memories;
        private bool _runningFlag = true;
        private int _type;

        private void Menu()
        {
            Console.WriteLine("1 - Create \"Memories\"");
            Console.WriteLine("2 - Create \"Pare\" and put into \"Memories\"");
            Console.WriteLine("3 - Increment");
            Console.WriteLine("4 - Decrement");
            Console.WriteLine("0 - Exit");
        }

        private void Execute(int choice)
        {
            switch (choice)
            {
                case 1:
                {
                    Console.WriteLine("Size: ");
                    var size = Convert.ToInt32(Console.ReadLine());
                    _memories = new Memories(size);
                    break;
                }
                case 2:
                {
                    if (_memories != null)
                    {
                        Console.WriteLine("Pare #1 (3 nums, Date, DD-MM-YYYY) - ");
                        Console.WriteLine("Day:");
                        var a = Convert.ToInt32(Console.ReadLine());
                        Console.WriteLine("Month:");
                        var b = Convert.ToInt32(Console.ReadLine());
                        Console.WriteLine("Year:");
                        var c = Convert.ToInt32(Console.ReadLine());
                        var date = new Date(a, b, c);

                        Console.WriteLine("Pare #1 (3 nums, Time, HH-MM-SS):");
                        Console.WriteLine("Hours:");
                        c = Convert.ToInt32(Console.ReadLine());
                        Console.WriteLine("Minutes:");
                        b = Convert.ToInt32(Console.ReadLine());
                        Console.WriteLine("Seconds:");
                        a = Convert.ToInt32(Console.ReadLine());
                        var time = new Time(a, b, c);

                        var p = new Pair(date, time);
                        Console.WriteLine("Index - ");
                        var index = Convert.ToInt32(Console.ReadLine());
                        _memories.SetPair(index, p);
                        Console.WriteLine("Successful!");
                    }
                    else
                    {
                        Console.WriteLine("Memories == null!");
                    }

                    break;
                }
                case 3:
                    WriteTriadPair(true);
                    break;
                case 4:
                    WriteTriadPair(false);
                    break;
                case 0:
                    _runningFlag = false;
                    break;
                default:
                    break;
            }
        }

        private void WriteTriadPair(bool incrementFlag)
        {
            if (_memories != null)
            {
                var index = Convert.ToInt32(Console.ReadLine());
                if (_memories.GetPair(index) == null)
                {
                    Console.WriteLine("Pair with this index is null!");
                    return;
                }

                Console.WriteLine("1 - Date, 2 - Time");
                _type = Convert.ToInt32(Console.ReadLine());
                switch (_type)
                {
                    case 1:
                        Console.WriteLine("1 - Day, 2 - Month, 3 - Year");
                        break;
                    case 2:
                        Console.WriteLine("1 - Seconds, 2 - Minutes, 3 - Hours");
                        break;
                    default:
                        Console.WriteLine("Incorrect type!");
                        return;
                }

                var position = Convert.ToInt32(Console.ReadLine());
                TriadNumber enumPosition;
                switch (position)
                {
                    case 1:
                        enumPosition = TriadNumber.FIRST;
                        break;
                    case 2:
                        enumPosition = TriadNumber.SECOND;
                        break;
                    case 3:
                        enumPosition = TriadNumber.THIRD;
                        break;
                    default:
                        Console.WriteLine("Incorrect position!");
                        return;
                }

                if (incrementFlag)
                {
                    if (_type == 1)
                    {
                        _memories.GetPair(index).GetKey().IncrementAndGet(enumPosition);
                    }
                    else
                    {
                        _memories.GetPair(index).GetValue().IncrementAndGet(enumPosition);
                    }
                }
                else
                {
                    if (_type == 1)
                    {
                        _memories.GetPair(index).GetKey().DecrementAndGet(enumPosition);
                    }
                    else
                    {
                        _memories.GetPair(index).GetValue().DecrementAndGet(enumPosition);
                    }
                }
            }
            else
            {
                Console.WriteLine("Memories == null!");
            }
        }

        private void PrintData()
        {
            if (_memories == null)
            {
                Console.WriteLine("Memories == NULL");
            }
            else
            {
                for (var i = 0; i < _memories.GetSize(); i++)
                {
                    var p = _memories.GetPair(i);
                    if (p != null)
                    {
                        var t1 = p.GetKey();
                        var t2 = p.GetValue();
                        if (t1 != null && t2 != null)
                        {
                            Console.Write(i + ") ");
                            Console.Write(t1.Get(TriadNumber.FIRST) + "-" + t1.Get(TriadNumber.SECOND) + "-" + t1.Get(TriadNumber.THIRD) + "  ");
                            Console.Write(t2.Get(TriadNumber.THIRD) + "-" + t2.Get(TriadNumber.SECOND) + "-" + t2.Get(TriadNumber.FIRST) + "\n");
                        }
                        else
                        {
                            Console.WriteLine(i + ") NULL");
                        }
                    }
                    else
                    {
                        Console.WriteLine(i + ") NULL");
                    }
                }
            }
        }


        public void Start()
        {
            while (_runningFlag)
            {
                PrintData();
                Menu();
                try
                {
                    var choice = Convert.ToInt32(Console.ReadLine());
                    Execute(choice);
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                }
            }
        }
    }
}