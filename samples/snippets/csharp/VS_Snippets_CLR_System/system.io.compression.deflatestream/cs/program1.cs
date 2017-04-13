// <snippet1>
using System;
using System.Collections.Generic;
using System.IO;
using System.IO.Compression;

namespace ConsoleApplication
{
    class Program
    {
        static void Main(string[] args)
        {
            string directoryPath = @"c:\users\public\reports";
            DirectoryInfo directorySelected = new DirectoryInfo(directoryPath);

            foreach (FileInfo fileToCompress in directorySelected.EnumerateFiles())
            {
                Compress(fileToCompress);
            }
        }

        public static void Compress(FileInfo fileToCompress)
        {
            using (FileStream originalFileStream = fileToCompress.OpenRead())
            {
                if ((File.GetAttributes(fileToCompress.FullName) & FileAttributes.Hidden) != FileAttributes.Hidden & fileToCompress.Extension != ".cmp")
                {
                    using (FileStream compressedFileStream = File.Create(fileToCompress.FullName + ".cmp"))
                    {
                        using (DeflateStream compressionStream = new DeflateStream(compressedFileStream, CompressionLevel.Fastest))
                        {
                            originalFileStream.CopyTo(compressionStream);
                        }
                    }
                }
            }
        }
    }
}
// </snippet1>
