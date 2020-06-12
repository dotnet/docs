// <snippet4>
using System;
using System.IO;
using System.IO.Compression;

namespace ConsoleApplication
{
    class Program
    {
        static void Main(string[] args)
        {
            string zipPath = @"c:\users\exampleuser\start.zip";
            string extractPath = @"c:\users\exampleuser\extract";
            string newFile = @"c:\users\exampleuser\NewFile.txt";

            using (ZipArchive archive = ZipFile.Open(zipPath, ZipArchiveMode.Update))
            {
                archive.CreateEntryFromFile(newFile, "NewEntry.txt", CompressionLevel.Fastest);
                archive.ExtractToDirectory(extractPath);
            }
        }
    }
}
// </snippet4>
