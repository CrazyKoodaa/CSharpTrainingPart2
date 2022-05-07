using System;

#nullable enable

namespace outParameters
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
            Console.Write($"Enter a number: ");
            if (int.TryParse(Console.ReadLine(), out int input))
            {
                var output1 = ReturnThreeValues(input, out double output2, out int output3);
                Console.WriteLine($"Outputs: plus one = {output1}, half = {output2:F2}, twice = {output3}");
            }

            var i = 1;
            var guy = new Guy(26, "Joe"); // { Name = "Joe", Age = 26 };
            Console.WriteLine($"i is {i} and guy is {guy}");
            ModifyAnIntAndGuy(ref i, ref guy);
            Console.WriteLine($"Now i is {i} and guy is {guy}");

            // Those values are fine for your average person
            CheckTemperature(101.3);

            // A dog's temperature should be between 100.5 and 102.5 F
            CheckTemperature(101.3, 102.5, 100.5);

            // Bob's Temperatur is always a litte low, so set tooLow to 95.5
            CheckTemperature(96.2, tooLow: 95.5);

            Guy guy1;
            guy = new Guy(26, "yep");// { Age = 26 };
            Console.WriteLine($"guy.Name is {guy.Name.Length} letters long");
        }

        public static int ReturnThreeValues(int value, out double half, out int twice)
        {
            half = value / 2f;
            twice = value * 2;
            return value + 1;
        }

        static void ModifyAnIntAndGuy(ref int valueRef, ref Guy guyRef)
        {
            valueRef += 10;
            //guyRef.Name = "Bob";
            //guyRef.Age = 37;    
        }

        static void CheckTemperature(double temp, double tooHigh = 99.5, double tooLow = 96.5)
        {
            if (temp < tooHigh && temp > tooLow) Console.WriteLine($"{temp} degrees F - feeling good!");
            else Console.WriteLine($"Ug-oh {temp} degrees F -> better see a doctor");
        }
    }

    class Guy
    {
        public string Name { get; private set; }
        public int Age { get; private set; }
        public override string ToString()
        {
            return $"a {Age}-year-old named {Name}"; 
        }

        // adding this constructor and setting the set private helps to avoid nulls
        public Guy(int age, string name)
        {
            this.Age = age;
            this.Name = name;
        }
    }
}
