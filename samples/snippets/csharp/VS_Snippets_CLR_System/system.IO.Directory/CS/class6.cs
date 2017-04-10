// <snippet14>
using System;
using System.IO;

namespace ConsoleApplication
{
    class Program
    {
        static void Main(string[] args)
        {
            string sourceDirectory = @"C:\source";
            string destinationDirectory = @"C:\destination";

            try
            {
                Directory.Move(sourceDirectory, destinationDirectory);  
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }
    }
}
// </snippet14>
