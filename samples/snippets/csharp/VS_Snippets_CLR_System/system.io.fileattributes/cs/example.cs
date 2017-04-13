// <snippet1>
using System;
using System.IO;

namespace ConsoleApplication
{
    class Program
    {
        static void Main(string[] args)
        {
            FileAttributes attributes = File.GetAttributes("c:/Temp/testfile.txt");
            if ((attributes & FileAttributes.ReadOnly) == FileAttributes.ReadOnly)
            {
                Console.WriteLine("read-only file");
            }
            else
            {
                Console.WriteLine("not read-only file");
            }
        }
    }
}
// </snippet1>