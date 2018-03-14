// <snippet1>
using System;
using System.IO;
using System.IO.Compression;

namespace ConsoleApplication1
{
    class Program
    {
        static void Main(string[] args)
        {
            string zipPath = @"c:\example\result.zip";

            using (ZipArchive archive = ZipFile.OpenRead(zipPath))
            {
                foreach (ZipArchiveEntry entry in archive.Entries)
                {
                    float compressedRatio = (float)entry.CompressedLength / entry.Length;
                    float reductionPercentage = 100 - (compressedRatio * 100);

                    Console.WriteLine (string.Format("File: {0}, Compressed {1:F2}%", entry.Name, reductionPercentage)); 
                }
            } 
        }
    }
}
// </snippet1>
