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

                LINQ methods that take a Func<T1,T2> parameter can be called with a lambda that takes a T1 parameter and returns a T2 value
                Use the => operator to create switch expressions, which are like switch statements that return a value.
                Use yield return statements to create methods that return enumerable sequences.
                When a method executes a yield return, it returns the next value in the sequence. The next time tihe method is called, it resumes execution at the next statement after the last yield return that was executed

            */
        }
    }
}
