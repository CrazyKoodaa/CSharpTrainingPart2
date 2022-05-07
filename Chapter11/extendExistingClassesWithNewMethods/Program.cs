using System;
using System.Linq;

namespace extendExistingClassesWithNewMethods
{
    sealed class OrdinaryHuman
    {
        private int age;
        int weigth;

        public OrdinaryHuman(int weight)
        {
            this.weigth = weight;
        }

        public void GoToWork() { /* code to go to work */ }
        public void PayBills() { /* code to pay bills */ }
    }

    static class AmazeballsSerum
    {
        public static string BreakWalls(this OrdinaryHuman h, double wallDensity)
        {
            return ($"I broke through a wall of {wallDensity} density.");
        }
    }
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
            OrdinaryHuman steve = new OrdinaryHuman(185);
            Console.WriteLine(steve.BreakWalls(89.2));

            
        }
    }
}
             