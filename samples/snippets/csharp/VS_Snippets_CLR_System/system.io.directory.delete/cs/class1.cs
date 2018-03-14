// <snippet1>
using System;
using System.IO;

namespace ConsoleApplication
{
    class Program
    {
        static void Main(string[] args)
        {
            string subPath = @"C:\NewDirectory\NewSubDirectory";

            try
            {
                Directory.CreateDirectory(subPath);   
                Directory.Delete(subPath);

                bool directoryExists = Directory.Exists(@"C:\NewDirectory");
                bool subDirectoryExists = Directory.Exists(subPath);

                Console.WriteLine("top-level directory exists: " + directoryExists);
                Console.WriteLine("sub-directory exists: " + subDirectoryExists);
            }
            catch (Exception e)
            {
                Console.WriteLine("The process failed: {0}", e.Message);
            }
        }
    }
}
// </snippet1>
