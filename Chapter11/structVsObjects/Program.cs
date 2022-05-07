using System;

namespace structVsObjects
{
    /* 
     * Structs are value types VW object are reference types  
     */
    internal class Program
    {
        public struct Dog
        {
            public string Name { get; set; }
            public string Breed { get; set; }
            public Dog(string name, string breed)
            {
                this.Name = name;
                this.Breed = breed;
            }
            public void Speak()
            {
                Console.WriteLine($"My name is {Name} and I'm a {Breed}");
            }
        }
                    
        public class Canine 
        { 
            public string Name { get; set; }
            public string Breed { get; set; }
            public Canine(string name, string breed)
            {
                this.Name = name;
                this.Breed = breed;
            }
            public void Speak()
            {
                Console.WriteLine($"My name is {Name} and I'm a {Breed}");
            }
        }


        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
            Canine spot = new Canine("Spot", "pug");
            Canine bob = spot;
            bob.Name = "Spike";
            bob.Breed = "beagle";

            spot.Speak();

            Dog jake = new Dog("Jake", "poodle");
            Dog betty = jake;
            betty.Name = "Betty";
            betty.Breed = "pit bull";
            jake.Speak();
              
        }
    }
}
