// <snippet3>
using System;
using System.Text;
using System.IO;
using System.IO.Compression;

namespace ExampleConsoleApplication
{
    class Program
    {
        static void Main(string[] args)
        {
            UnicodeEncoding uniEncode = new UnicodeEncoding();

            byte[] bytesToCompress = uniEncode.GetBytes("example text to compress and decompress");
            Console.WriteLine("starting with: " + uniEncode.GetString(bytesToCompress));

            using (FileStream fileToCompress = File.Create("examplefile.gz"))
            {
                using (GZipStream compressionStream = new GZipStream(fileToCompress, CompressionMode.Compress))
                {
                    compressionStream.Write(bytesToCompress, 0, bytesToCompress.Length);
                }
            }

            byte[] decompressedBytes = new byte[bytesToCompress.Length];
            using (FileStream fileToDecompress = File.Open("examplefile.gz", FileMode.Open))
            {
                using (GZipStream decompressionStream = new GZipStream(fileToDecompress, CompressionMode.Decompress))
                {
                    decompressionStream.Read(decompressedBytes, 0, bytesToCompress.Length);
                }
            }
            
            Console.WriteLine("ending with: " + uniEncode.GetString(decompressedBytes));
        }
    }
}
// </snippet3>