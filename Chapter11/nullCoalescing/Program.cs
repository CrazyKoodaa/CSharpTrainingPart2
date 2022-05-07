using System;
using System.IO;

#nullable enable

namespace nullCoalescing
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
            using (var stringReader = new StringReader(""))
            {
                // use stringReader.ReadLine() ?? String.Empty; if you want to return Empty instead of null
                var nextLine = stringReader.ReadLine(); // ?? String.Empty;

                // or if the nextLine is null, then assign the Text (the...
                nextLine ??= "(the first line is null)";
                Console.WriteLine($"Line length is: {nextLine.Length}");


                // Nullable value types can be null and handled safely
                Nullable<bool> optionalYesNoAnswer = null;
                // or with C#
                bool? optionalYesNoAnswerYes = null;

                if (optionalYesNoAnswerYes.HasValue) Console.WriteLine("Yes it has a value");
                else Console.WriteLine("Nope");


            }
        }
    }
}
