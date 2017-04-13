// <snippet2>
using System;
using System.IO;
using System.IO.Compression;

namespace ConsoleApplication
{
    class Program
    {
        static void Main(string[] args)
        {
            using (FileStream zipToOpen = new FileStream(@"c:\users\exampleuser\release.zip", FileMode.Open))
            {
                using (ZipArchive archive = new ZipArchive(zipToOpen, ZipArchiveMode.Update))
                {
                    ZipArchiveEntry readmeEntry = archive.CreateEntry("Readme.txt", CompressionLevel.Optimal);
                    using (StreamWriter writer = new StreamWriter(readmeEntry.Open()))
                    {
                            writer.WriteLine("Information about this package.");
                            writer.WriteLine("========================");
                    }
                }
            }
        }
    }
}
// </snippet2>