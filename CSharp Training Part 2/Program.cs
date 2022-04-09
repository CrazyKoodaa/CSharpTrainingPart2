using System;

namespace CSharp_Training_Part_2
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
            /*
                from comic in comics
                orderby prices[comic.Issue] descending
                group comic by CalculatePriceRange(comic) into priceGroup
                select priceGroup;

                from comic in comics
                orderby comic.Issue descending
                join review in reviews on comic.Issue equals review.Issue
                select $"{review.Critic} rated #{comic.Issue} '{comic.Name}' {review.Score:0.00}";

            either this:
                var score = 0;
                switch (card.Suit)
                {
                    case Suits.Spades: score = 6; break;
                    case Suits.Hearts: score = 4; break;
                    default: score = 2; break;
                }
            or with switch Expression style:

                var score = card.Suit switch
                {
                    Suits.Spades => 6,
                    Suits.Hearts => 4,
                    _ => 2,
                };
            */
        }
    }
}
