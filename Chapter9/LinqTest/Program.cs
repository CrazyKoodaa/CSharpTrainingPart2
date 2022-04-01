using System;

namespace LinqTest
{
    using System.Linq;
    using System.Collections.Generic;
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
            List<int> numbers = new List<int>();
            for (int i = 1; i < 100; i++)
            {
                numbers.Add(i);
            }
            IEnumerable<int> firstAndLastFive = numbers.Take(5).Concat(numbers.TakeLast(5));
            foreach (int i in firstAndLastFive)
                Console.WriteLine(i);

            IEnumerable<int> rangeNumber = numbers.GetRange(7, 5);
            foreach (int i in rangeNumber)
                Console.WriteLine(i);

            Console.WriteLine(numbers.GetRange(0, 2).Sum());
            Console.WriteLine(numbers.GetRange(0,10).Average());

            Console.WriteLine(new int[] { 1, -12, -3, 4, -5, 6, 7 }.Min());
            Console.WriteLine(new int[] { 1, -12, -3, 4, -5, 6, 7 }.Max());
            Console.WriteLine(new int[] { 1, -12, -3, 4, -5, 6, 7 }.Count());

            Console.WriteLine(new int[] { 1, -12, -3, 4, -5, 6, 7 }.Last());
            Console.WriteLine(new int[] { 1, -12, -3, 4, -5, 6, 7 }.Skip(2).Sum());
            Console.WriteLine(new int[] { 1, -12, -3, 4, -5, 6, 7 }.Reverse().Last());


            int[] values = new int[] { 0, 12, 44, 36, 92, 54, 13, 8 };
            IEnumerable<int> result = 
                from v in values
                where v < 37
                orderby -v
                select v;

            foreach (int v in result)
                Console.Write(v + " ");

            Console.WriteLine();
            AddSubtract a = new AddSubtract() { Value = 5 }
            .Add(5)
            .Subtract(3)
            .Add(9)
            .Subtract(12);

            Console.WriteLine($"Result: {a.Value}");
        }
    }

    // this is a class for using two methods with chaining possibility
    class AddSubtract
    {
        public int Value { get; set; }
        public AddSubtract Add(int i)
        {
            Console.WriteLine($"Value: {Value}, adding {i}");
            return new AddSubtract() { Value = Value + i };
        }
        public AddSubtract Subtract(int i)
        {
            Console.WriteLine($"Value: {Value}, subtracting {i}");
            return new AddSubtract() { Value = Value - i };
        }
    }
}
