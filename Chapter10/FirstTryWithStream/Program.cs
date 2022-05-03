using System;
using System.IO;
using System.Security.Cryptography;
using System.Text;

namespace FirstTryWithStream
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");

            var folder = Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData);


            FileStream stream = new FileStream($"{folder}{Path.DirectorySeparatorChar}secret.txt", FileMode.OpenOrCreate, FileAccess.Write);

            DESCryptoServiceProvider cryptic = new DESCryptoServiceProvider();

            cryptic.Key = ASCIIEncoding.ASCII.GetBytes("ABCDEFGH");
            cryptic.IV = ASCIIEncoding.ASCII.GetBytes("ABCDEFGH");

            CryptoStream crStream = new CryptoStream(stream,
               cryptic.CreateEncryptor(), CryptoStreamMode.Write);


            byte[] data = ASCIIEncoding.ASCII.GetBytes("Hello World!");

            crStream.Write(data, 0, data.Length);

            crStream.Close();
            stream.Close();


            var sw = new StreamWriter($"{folder}{Path.DirectorySeparatorChar}secret_plan.txt");

            //StreamWriter sw = new StreamWriter(System.IO.File.OpenWrite(args[0]));
            sw.WriteLine("How I'll defeat Captain Amazing");
            sw.WriteLine("Another genius secret plan by The Swindler");
            sw.WriteLine(@"I'll unleash my army of clones
upon the
citizens of Objectville");


            string location = "the mall";
            for (int number = 1; number <= 5; number++)
            {
                sw.WriteLine($"Clone #{number} attacks {location}");
                location = (location == "the mall") ? "downtown" : "the mall";

            }
            sw.Close();

            var reader = new StreamReader($"{folder}{Path.DirectorySeparatorChar}secret_plan.txt");
            var writer = new StreamWriter($"{folder}{Path.DirectorySeparatorChar}emailToCaptainA.txt");


            writer.WriteLine(@"To: CaptainAmazing@objectville.net
From: Commissioner@objectville.net
Subject: Can you save the day ... again?

We've discovered the Swindler's terrible plan:");

            while (!reader.EndOfStream)
            {
                var lineFromThePlan = reader.ReadLine();
                writer.WriteLine($"The plan -> {lineFromThePlan}");
            }
            writer.WriteLine();
            writer.WriteLine("Can you help us?");

            writer.Close();
            reader.Close();


            Console.WriteLine("\nReading from CryptoFile");
            reader = new StreamReader($"{folder}{Path.DirectorySeparatorChar}secret.txt");
            while (!reader.EndOfStream)
            {
                Console.WriteLine(reader.ReadLine());
            }



            crStream = new CryptoStream(stream, cryptic.CreateDecryptor(), CryptoStreamMode.Read);

            StreamReader reader = new StreamReader(crStream);

            string data = reader.ReadToEnd();

            reader.Close();
            stream.Close();


        }
    }
}
