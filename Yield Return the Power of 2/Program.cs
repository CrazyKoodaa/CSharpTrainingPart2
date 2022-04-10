using System;
using System.Collections;
using System.Collections.Generic;

namespace Yield_Return_the_Power_of_2
{
    class PowersOfTwo : IEnumerable<int>
    {
        public IEnumerator<int> GetEnumerator()
        {
            var maxPower = Math.Round(Math.Log(int.MaxValue, 2));
            for (int i = 2; i <= maxPower; i++)
            {
                yield return (int)Math.Pow(2,i);
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }

    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");

            var counting = new PowersOfTwo();
            foreach (var items in counting)
                Console.Write(items + " ");
        }
    }
}
