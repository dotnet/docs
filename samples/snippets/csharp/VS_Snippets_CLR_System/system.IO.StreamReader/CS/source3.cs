//<snippet21>
using System;
using System.IO;

public class ReadBuf
{
    private const string FILE_NAME = "MyFile.txt";

    public static void Main()
    {
        if (!File.Exists(FILE_NAME))
        {
            Console.WriteLine($"{FILE_NAME} does not exist.");
            return;
        }
        using (FileStream f = new FileStream(FILE_NAME, FileMode.Open, FileAccess.Read, FileShare.Read))
        {
            // Create an instance of BinaryReader that can
            // read bytes from the FileStream.
            using (BinaryReader br = new BinaryReader(f, Encoding.UTF8, true))
            {
                byte input;
                // While not at the end of the file, read lines from the file.
                while (br.PeekChar() > -1)
                {
                    input = br.ReadByte();
                    Console.WriteLine(input);
                }
            }
        }
    }
}
//</snippet21>
