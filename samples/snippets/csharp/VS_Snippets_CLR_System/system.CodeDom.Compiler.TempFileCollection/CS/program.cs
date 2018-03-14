//<Snippet1>
using System;
using System.CodeDom.Compiler;
using System.IO;

class Program
{
    static void Main(string[] args)
    {
        // Create a directory in the current working directory.
        Directory.CreateDirectory("testDir");
        TempFileCollection tfc = new TempFileCollection("testDir", false);
        // Returns the file name relative to the current working directory.
        string fileName = tfc.AddExtension("txt");
        Console.WriteLine(fileName);
        //<Snippet2>
        // Name a file in the test directory.
        string file2Name = "testDir\\test.txt";
        // Add the file to the temp directory and indicate it is to be kept.
        tfc.AddFile(file2Name, true);
        //</Snippet2>
        Console.WriteLine(tfc.Count);
        // Create and use the test files.
        FileStream fs1 = File.OpenWrite(fileName);
        FileStream fs2 = File.OpenWrite(file2Name);
        StreamWriter sw1 = new StreamWriter(fs1);
        StreamWriter sw2 = new StreamWriter(fs2);
        sw1.WriteLine("Test string");
        sw2.WriteLine("Test string");
        sw1.Close();
        sw2.Close();
        tfc.Delete();
        Console.WriteLine(tfc.Count);
        try
        {
            // This call should succeed.
            File.OpenRead(file2Name);
            // This call should fail.
            File.OpenRead(fileName);
        }
        catch (FileNotFoundException e)
        {
            Console.WriteLine(e.Message);
        }

    }

}
//</Snippet1>
