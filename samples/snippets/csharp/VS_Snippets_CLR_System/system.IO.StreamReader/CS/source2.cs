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
            Console.WriteLine($"{FILE_NAME} does not exist!");
            return;
        }
        // Create an instance of StreamReader characters from the file.
        using (StreamReader sr = new StreamReader(FILE_NAME))
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
