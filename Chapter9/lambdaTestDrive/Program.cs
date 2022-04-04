using System;

namespace lambdaTestDrive
{
    class Program
    {
        static Random random => new Random();
        
        /*
        static double GetRandomDouble(int max) 
        {
            return max * random.NextDouble();
        }
        */
        // is the same as
        static double GetRandomDouble(int max) => max * random.NextDouble();

        /*
        static void PrintValue(double d)
        {
            Console.WriteLine($"The value is {d:0.0000}");
        }
        */
        // is the same as
        static void PrintValue(double d) => Console.WriteLine($"The value is {d:0.0000}");
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
            var value = Program.GetRandomDouble(100);
            Program.PrintValue(value);
        }
    }
}
