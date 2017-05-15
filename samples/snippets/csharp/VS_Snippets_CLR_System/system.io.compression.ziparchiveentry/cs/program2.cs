// <snippet2>
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

            using (ZipArchive archive = ZipFile.Open(zipPath, ZipArchiveMode.Update))
            {
                ZipArchiveEntry entry = archive.GetEntry("ExistingFile.txt");
                using (StreamWriter writer = new StreamWriter(entry.Open()))
                {
                    writer.BaseStream.Seek(0, SeekOrigin.End);
                    writer.WriteLine("append line to file");
                }
                entry.LastWriteTime = DateTimeOffset.UtcNow.LocalDateTime;
            }
        }
    }
}
// </snippet2>
