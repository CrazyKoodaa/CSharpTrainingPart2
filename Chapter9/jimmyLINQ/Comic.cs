using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace jimmyLINQ
{
    public class Comic
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

        public static readonly IEnumerable<Review> Reviews = new[]
        {
            new Review() { Issue = 36, Critic = Critics.MuddyCritic, Score = 37.6 },
            new Review() { Issue = 74, Critic = Critics.RottenTornadoes, Score = 22.8 },
            new Review() { Issue = 74, Critic = Critics.MuddyCritic, Score = 84.2 },
            new Review() { Issue = 83, Critic = Critics.RottenTornadoes, Score = 89.4 },
            new Review() { Issue = 97, Critic = Critics.MuddyCritic, Score = 98.1 },
        };

    }
}
