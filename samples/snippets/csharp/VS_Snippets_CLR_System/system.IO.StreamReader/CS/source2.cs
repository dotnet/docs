//<snippet20>
using System;
using System.IO;

public class CompBuf
{
    private const string FILE_NAME = "MyFile.txt";

    public static void Main()
    {
        if (!File.Exists(FILE_NAME))
        {
            Console.WriteLine("{0} does not exist!", FILE_NAME);
            return;
        }
        FileStream fsIn = new FileStream(FILE_NAME, FileMode.Open,
            FileAccess.Read, FileShare.Read);
        // Create an instance of StreamReader that can read
        // characters from the FileStream.
        using (StreamReader sr = new StreamReader(fsIn))
        {
            string input;
            // While not at the end of the file, read lines from the file.
            while (sr.Peek() > -1)
            {
                input = sr.ReadLine();
                Console.WriteLine(input);
            }
        }
    }
}
//</snippet20>
