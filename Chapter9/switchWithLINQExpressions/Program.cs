using System;

namespace switchWithLINQExpressions
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");

            // the next few lines:
            var score = 0;
            switch (card.Suit)
            {
                case Suits.Spades:
                    score = 6;
                    break;
                case Suits.Hearts:
                    score = 4;
                    break;
                default:
                    score = 2;
                    break;
            }

            // to this:
            var score = card.Suit switch
            {
                Suits.Spades => 6,
                Suits.Hearts => 4,
                _ => 2,
            };
        }
    }

    internal class card
    {
    }
}
