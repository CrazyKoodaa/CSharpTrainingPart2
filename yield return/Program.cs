using System;
using System.Collections.Generic;

namespace yield_return
{
    internal class Program
    {
        static IEnumerable<string> SimpleEnumerable()
        {
            yield return "apples";
            yield return "oranges";
            yield return "bananas";
            yield return "unicorns";
        }
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
            foreach (var s in SimpleEnumerable()) Console.WriteLine(s);
        }
    }
}
