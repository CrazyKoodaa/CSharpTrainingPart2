using System;
using System.IO;
using System.Text;

namespace MemoryStreamApp
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
            using (var ms = new MemoryStream())
            {
                using (var sw = new StreamWriter(ms))
                {
                    sw.WriteLine($"The value is {123.45678:0.00}");

                }
                Console.WriteLine(Encoding.UTF8.GetString(ms.ToArray()));
            }       

        }
    } 
}
          