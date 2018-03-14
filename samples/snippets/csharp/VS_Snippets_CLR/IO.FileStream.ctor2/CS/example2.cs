// <snippet2>
using System;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace ConsoleApplication
{
    class Program
    {
        static void Main(string[] args)
        {
            WriteToFile();
        }

        static async void WriteToFile()
        {
            byte[] bytesToWrite = Encoding.Unicode.GetBytes("example text to write");
            using (FileStream createdFile = File.Create("c:/Temp/testfile.txt", 4096, FileOptions.Asynchronous))
            {
                await createdFile.WriteAsync(bytesToWrite, 0, bytesToWrite.Length);
            }
        }
    }
}
// </snippet2>