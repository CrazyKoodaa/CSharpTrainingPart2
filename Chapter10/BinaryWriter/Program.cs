using System;
using System.IO;
using System.Text;


/* 
 * C# and .Net uses UTF-16 when storing charactes and text in memory, treating a string as a read-only collection of chars
 * Encoding.UTF8.GetString => converts UTF-8 byte array to a string
 * Encoding.Unicode => converts byte array encoded with UTF-16 to string
 * Encoding.UTF32 => converts UTF-32 byte array to string
 * /u => escape sequence to include Unicode in C# Strings
 * /U => UTF 32 (4 fixed bytes)
 * 
 * 
 * 
 */
namespace BinaryWriterApp
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
            int intValue = 48769414;
            string stringValue = "Hello!";
            byte[] byteArray = { 47, 129, 0, 116 };
            float floatValue = 491.695f;
            char charValue = 'E';

            using (var output = File.Create("binarydata.dat"))
            using (var writer = new BinaryWriter(output))
            {
                writer.Write(intValue);
                writer.Write(stringValue);
                writer.Write(byteArray);
                writer.Write(charValue);
                writer.Write(floatValue);
                


            }

            byte[] dataWritten = File.ReadAllBytes("binarydata.dat");
            foreach (byte b in dataWritten)
            {
                Console.Write("{0:x2} ", b);

            }
            Console.WriteLine(" - {0} bytes", dataWritten.Length);



            using (var input = File.OpenRead("binarydata.dat"))
            using (var reader = new BinaryReader(input))
            {
                int intRead = reader.ReadInt32();
                string stringRead = reader.ReadString();
                byte[] byteArrayRead = reader.ReadBytes(4);
                float floatRead = reader.ReadSingle();
                char charRead = reader.ReadChar();

                Console.Write("int {0}, string {1}, bytes ", intRead, stringRead);
                foreach (byte b in byteArrayRead)
                {
                    Console.Write("{0} ", b);
                }
                Console.Write(" float {0}, char {1}, ", floatRead, charRead);
            }

            Console.WriteLine("\n");
            var position = 0;
            using (var reader = new StreamReader("textdata.txt"))
            {
                while (!reader.EndOfStream)
                {
                    var buffer = new char[16];
                    var bytesRead = reader.ReadBlock(buffer, 0, 16);
                    Console.Write($"{position:x4}: ");
                    position += bytesRead;

                    for (int i = 0; i < 16; i++)
                    {
                        if (i < bytesRead) Console.Write($"{(byte)buffer[i]:x2} ");
                        else Console.Write("  ");
                        if (i == 7) Console.Write("-- ");
                    }

                    var bufferContents = new string(buffer);
                    Console.WriteLine($"  {bufferContents.Substring(0, bytesRead)}");

                }
            }

            Console.WriteLine("\n");
            position = 0;
            using (var reader = new StreamReader("binarydata.dat"))
            {
                while (!reader.EndOfStream)
                {
                    var buffer = new char[16];
                    var bytesRead = reader.ReadBlock(buffer, 0, 16);
                    Console.Write($"{position:x4}: ");
                    position += bytesRead;

                    for (int i = 0; i < 16; i++)
                    {
                        if (i < bytesRead) Console.Write($"{(byte)buffer[i]:x2} ");
                        else Console.Write("  ");
                        if (i == 7) Console.Write("-- ");
                    }

                    var bufferContents = new string(buffer);
                    Console.WriteLine($"  {bufferContents.Substring(0, bytesRead)}");

                }
            }

            Console.WriteLine();
            Console.WriteLine();
            position = 0;
            using (Stream input = File.OpenRead("binarydata.dat"))
            {
                var buffer = new byte[16];
                while (position < input.Length)
                {
                    var bytesRead = input.Read(buffer, 0, buffer.Length);


                    Console.Write($"{position:x4}: ");
                    position += bytesRead;

                    for (int i = 0; i < 16; i++)
                    {
                        if (i < bytesRead) Console.Write($"{(byte)buffer[i]:x2} ");
                        else Console.Write("  ");
                        if (i == 7) Console.Write("-- ");
                        if (buffer[i] < 0x20 || buffer[i] > 0x7F) buffer[i] = (byte)'.';
                    }

                    var bufferContents = Encoding.UTF8.GetString(buffer);
                    Console.WriteLine($"  {bufferContents.Substring(0, bytesRead)}");
                }

            }
             

                        
            Console.WriteLine("------------------------------- ARGS");
            position = 0;
            using (Stream input = File.OpenRead(args[0]))
            {
                var buffer = new byte[16];
                int bytesRead;

                while ((bytesRead = input.Read(buffer, 0, buffer.Length)) > 0)
                {
                   

                    Console.Write($"{position:x4}: ");
                    position += bytesRead;

                    for (int i = 0; i < 16; i++)
                    {
                        if (i < bytesRead) Console.Write($"{(byte)buffer[i]:x2} ");
                        else Console.Write("  ");
                        if (i == 7) Console.Write("-- ");
                        if (buffer[i] < 0x20 || buffer[i] > 0x7F) buffer[i] = (byte)'.';
                    }

                    var bufferContents = Encoding.UTF8.GetString(buffer);
                    Console.WriteLine($"  {bufferContents.Substring(0, bytesRead)}");
                }

            }

        }
    }
}
