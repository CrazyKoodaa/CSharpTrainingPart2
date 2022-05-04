using System;
using System.IO;

namespace DirectoryStuff
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");

            if (!Directory.Exists(@"C:\SYP")) Directory.CreateDirectory(@"C:\SYP");
            if (Directory.Exists(@"C:\SYP\Bonk")) Directory.Delete(@"C:\SYP\Bonk");
            Directory.CreateDirectory(@"C:\SYP\Bonk");
            Directory.SetCreationTime(@"C:\SYP\Bonk", new DateTime(1996, 09, 23));
            string[] files = Directory.GetFiles(@"C:\SYP\", "*.log", SearchOption.AllDirectories);
            File.WriteAllText(@"C:\SYP\Bonk\weirdo.txt",
                @"First Line
Second line
Third Line");
            //File.Encrypt(@"C:\SYP\Bonk\weirdo.txt");
            File.Copy(@"C:\SYP\Bonk\weirdo.txt", @"C:\SYP\copy.txt");
            DateTime myTime = Directory.GetCreationTime(@"C:\SYP\Bonk");
            File.SetLastWriteTime(@"C:\SYP\copy.txt", myTime);
            File.Delete(@"C:\SYP\Bonk\weirdo.txt");

        }
    }
}
