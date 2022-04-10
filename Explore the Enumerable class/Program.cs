using System;
using System.Collections.Generic;
using System.Linq;

namespace Explore_the_Enumerable_class
{
    internal class Program
    {
        public enum Sport
        {
            Football,
            Baseball,
            Basketball,
            Hockey,
            Boxing,
            Rugby, 
            Fencing,
        }
        class ManualSportEnumerator : IEnumerator<Sport>
        {
            public static int current = -1;

            public ManualSportEnumerator()
            {
            }

            public Sport Current { get { return (Sport)current; } }
            public void Dispose() { return; }
            object System.Collections.IEnumerator.Current { get { return Current; } }
            public bool MoveNext()
            {
                var maxEnumValue = Enum.GetValues(typeof(Sport)).Length;
                if ((int) current >= maxEnumValue - 1 ) return false;
                current++;
                return true;
            }
            public void Reset() { current = 0; }
        }
        class ManualSportSequence : IEnumerable<Sport>
        {
            public IEnumerator<Sport> GetEnumerator() { return new ManualSportEnumerator();}
            System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { return GetEnumerator(); }
        }

        class BetterSportSequence : IEnumerable<Sport>
        {
            public IEnumerator<Sport> GetEnumerator()
            {
                int maxEnumValue = Enum.GetValues(typeof(Sport)).Length - 1;
                for (int i = 0; i <= maxEnumValue; i++) { yield return (Sport)i; }
            }

            System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator()
            {
                return GetEnumerator();
            }
            public Sport this[int index]
            {
                get { return (Sport)index;   /* return the specified index here */ }
                set { /* set the specified index to value here */ }
            }
        }
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
            
            var emptyInts = Enumerable.Empty<int>();
            var emptyComics = Enumerable.Empty<Comic>();

            var oneHundredThrees = Enumerable.Repeat(3, 100);
            var twelveYesStrings = Enumerable.Repeat("yes", 12);

            var eightyThreeObjects = Enumerable.Repeat(new { cost = 12.94M, sign = "ONE WAY", isTall = false }, 83);

            var sports = new ManualSportSequence();
            foreach (var sport in sports)
                Console.WriteLine(sport);

            var sportsBetter = new BetterSportSequence();
            Console.WriteLine(sportsBetter[3]);
            foreach (var sport in sportsBetter)
                Console.WriteLine(sport);
        }
    }
}
