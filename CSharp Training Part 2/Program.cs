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
            */
        }
    }
}
