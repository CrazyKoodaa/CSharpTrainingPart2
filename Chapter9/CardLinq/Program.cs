using System;
using System.Collections.Generic;
using System.Linq;

namespace CardLinq
{
    

    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
            var deck = new Deck()
                .Shuffle()
                .Take(16);

            var grouped =
                from card in deck
                group card by card.Suit into suitGroup
                orderby suitGroup.Key descending
                select suitGroup;

            foreach (var group in grouped)
            {
                Console.WriteLine($@"Group: {group.Key}
Count: {group.Count()}
Minimum: {group.Min()}
Maximum: {group.Max()}");
            }
        }
    }
}
