using System;
using System.IO;

class Program
{
    static void Main()
    {
        string[] filenames = {
            @"c:\temp\test-file.txt",
            @"\\127.0.0.1\c$\temp\test-file.txt",
            @"\\LOCALHOST\c$\temp\test-file.txt",
            @"\\.\c:\temp\test-file.txt",
            @"\\?\c:\temp\test-file.txt",
            @"\\.\UNC\LOCALHOST\c$\temp\test-file.txt" };

        foreach (string filename in filenames)
        {
            FileInfo fi = new(filename);
            Console.WriteLine($"file {fi.Name}: {fi.Length:N0} bytes");
        }
    }
}
// The example displays output like the following:
//      file test-file.txt: 22 bytes
//      file test-file.txt: 22 bytes
//      file test-file.txt: 22 bytes
//      file test-file.txt: 22 bytes
//      file test-file.txt: 22 bytes
//      file test-file.txt: 22 bytes
