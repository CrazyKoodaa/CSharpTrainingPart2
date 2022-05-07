using System;
using System.Collections.Generic;

namespace destruction
{
    class EvilClone
    {
        public static int CloneCount = 0;
        public int CloneID { get; } = ++CloneCount;
        public EvilClone() => Console.WriteLine($"Clone #{CloneID} is wreaking havoc");
        ~EvilClone() => Console.WriteLine($"Clone #{CloneID} got destroyed");
    }
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
            var stopwatch = System.Diagnostics.Stopwatch.StartNew();
            var clones = new List<EvilClone>();
            while (true)
            {
                switch (Console.ReadKey(true).KeyChar)
                {
                    case 'a': clones.Add(new EvilClone()); break;
                    case 'c': Console.WriteLine($"Clearing list at time {stopwatch.ElapsedMilliseconds}"); clones.Clear(); break;
                    case 'g': Console.WriteLine($"Collecting at time {stopwatch.ElapsedMilliseconds}"); GC.Collect(); break;
  
                }
            }
        }
    }
}
