// <Snippet4>
using System;
using System.IO;

public class TextFromFile
{
    private const string FILE_NAME = "MyFile.txt";

    public static void Main()
    {
        if (!File.Exists(FILE_NAME))
        {
            Console.WriteLine("{0} does not exist.", FILE_NAME);
            return;
        }
        using (StreamReader sr = File.OpenText(FILE_NAME))
        {
            String input;
            while ((input = sr.ReadLine()) != null)
            {
                Console.WriteLine(input);
            }
            Console.WriteLine ("The end of the stream has been reached.");
        }
    }
}
// </Snippet4>
