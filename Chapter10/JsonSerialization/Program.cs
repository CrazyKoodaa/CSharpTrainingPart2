using System;
using System.Collections.Generic;
using System.Text.Json;

namespace JsonSerialization
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");

            //https://docs.microsoft.com/en-us/dotnet/standard/serialization/


            var guys = new List<Guy>()
            {
                new Guy() { Name = "Bob", Clothers = new Outfit() { Top = "t-shirt", Buttom = "jeans"}, Hair = new HairStyle() { Color = HairColor.Red, Length = 3.5f}},
                new Guy() { Name = "Joe", Clothers = new Outfit() { Top = "polo", Buttom = "slacks"}, Hair = new HairStyle() { Color = HairColor.Gray, Length = 2.7f}},
            };
                                                       
            var options = new JsonSerializerOptions() {  WriteIndented = true };
            var jsonString = JsonSerializer.Serialize(guys, options);
            Console.WriteLine(jsonString);

            var copyOfGuys = JsonSerializer.Deserialize<List<Guy>>(jsonString);
            foreach (var guy in copyOfGuys)
                Console.WriteLine("I deserialized this guy {0}", guy);

            var dudes = JsonSerializer.Deserialize<Stack<Guy>>(jsonString);
            while (dudes.Count > 0)
            {
                var dude = dudes.Pop();
                Console.WriteLine($"Next dude: {dude.Name} with {dude.Hair} hair");
            }

            Console.WriteLine();
            Console.WriteLine(JsonSerializer.Serialize(3));
            Console.WriteLine(JsonSerializer.Serialize((long)-3));
            Console.WriteLine(JsonSerializer.Serialize((byte)0));
            Console.WriteLine(JsonSerializer.Serialize(float.MaxValue));
            Console.WriteLine(JsonSerializer.Serialize(float.MinValue));
            Console.WriteLine(JsonSerializer.Serialize(true));
            Console.WriteLine(JsonSerializer.Serialize("Elephant"));
            Console.WriteLine(JsonSerializer.Serialize("Elephant".ToCharArray()));
            Console.WriteLine(JsonSerializer.Serialize("🐘"));
        }
    }

    class Dude
    {
        public string Name { get; set; }
        public HairStyle Hair { get; set; }
    }

    class Guy
    {
        public string Name { get; set; }
        public HairStyle Hair { get; set; }
        public Outfit Clothers { get; set; }
        public override string ToString() => $"{Name} with {Hair} wearing {Clothers}";
    }

    class Outfit
    {
        public string Top { get; set; }
        public string Buttom { get; set; }
        public override string ToString() => $"{Top} and {Buttom}";

    }

    enum HairColor
    {
        Auburn, Black, Blonde, Blue, Brown, Gray, Platinum, Purple, Red, White
    }

    class HairStyle
    {
        public HairColor Color { get; set; }
        public float Length { get; set; }
        public override string ToString() => $"{Length:0.0} inch {Color} hair";
    }
}
