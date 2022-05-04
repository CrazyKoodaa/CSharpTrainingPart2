using System;
using System.IO;

namespace Avoid_filesystem_errors_with_using_statements
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");

            using (var sw = new StreamWriter("secret_plan.txt"))
            {
                sw.WriteLine("After this line the file will be closed automatically");
            }


            // Stacking is also allowed
            using (var reader = new StreamReader("secret_plan.txt"))
            using (var writer = new StreamWriter("email.txt"))
            {
                // blah blah blah
            }

        }
    }
}
