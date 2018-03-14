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
            string startPath = @"c:\example\start";
            string zipPath = @"c:\example\result.zip";
            string extractPath = @"c:\example\extract";

            ZipFile.CreateFromDirectory(startPath, zipPath, CompressionLevel.Fastest, true);

            ZipFile.ExtractToDirectory(zipPath, extractPath);
        }
    }
}
// </snippet2>