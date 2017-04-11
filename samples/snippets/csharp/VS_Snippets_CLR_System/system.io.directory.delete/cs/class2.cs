// <snippet2>
using System;
using System.IO;

namespace ConsoleApplication
{
    class Program
    {
        static void Main(string[] args)
        {
            string topPath = @"C:\NewDirectory";
            string subPath = @"C:\NewDirectory\NewSubDirectory";
            
            try
            {
                Directory.CreateDirectory(subPath);

                using (StreamWriter writer = File.CreateText(subPath + @"\example.txt"))
                {
                    writer.WriteLine("content added");
                }
                
                Directory.Delete(topPath, true);

                bool directoryExists = Directory.Exists(topPath);

                Console.WriteLine("top-level directory exists: " + directoryExists);
            }
            catch (Exception e)
            {
                Console.WriteLine("The process failed: {0}", e.Message);
            }
        }
    }
}
// </snippet2>
