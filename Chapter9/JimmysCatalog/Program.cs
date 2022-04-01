using System;
using System.Collections.Generic;
using System.Linq;


namespace JimmysCatalog
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
            
            Console.OutputEncoding = System.Text.Encoding.Unicode; //need this line so that Console writes the € instead of ?

            //IEnumerable<Comic> mostExpensive =
            var mostExpensive = 
                from comic in Comic.Catalog
                where Comic.Prices[comic.Issue] > 500
                orderby Comic.Prices[comic.Issue] descending // descending is the same as the "-" before Comic.Prices
                select comic;

            foreach (Comic item in mostExpensive)
                Console.WriteLine($"{item} is woth {Comic.Prices[item.Issue]:c}");

            // IEnumerable<string> mostExpensiveComicDescription =
            var mostExpensiveComicDescription =
                from comic in Comic.Catalog
                where Comic.Prices[comic.Issue] > 500
                orderby Comic.Prices[comic.Issue] descending
                select $"{comic} is worth {Comic.Prices[comic.Issue]:c}";

            foreach (string item in mostExpensiveComicDescription)
                Console.WriteLine(item);


        }
    }

    class Comic
    {
        public string Name { get; set; }
        public int Issue { get; set; }
        public override string ToString() => $"{Name} (#{Issue})";

        public static readonly IEnumerable<Comic> Catalog = new List<Comic>
        {
            new Comic { Name = "Johnny vs Pinko", Issue = 6},
            new Comic { Name = "Rock and Roll", Issue = 19},
            new Comic { Name = "WWork", Issue = 36},
            new Comic { Name = "HMaddness", Issue = 57},
            new Comic { Name = "Revenge", Issue = 68},
            new Comic { Name = "BMonday", Issue = 74},
            new Comic { Name = "Tattoo", Issue = 83},
            new Comic { Name = "Death of Object", Issue = 97},
        };

        public static readonly IReadOnlyDictionary<int, decimal> Prices = new Dictionary<int, decimal>
        {
            { 6, 3600M },
            { 19, 500M },
            { 36, 650M },
            { 57, 13525 },
            { 68, 250M },
            { 74, 75M },
            { 83, 25.75M },
            { 97, 35.25M },

        };
    }
}
