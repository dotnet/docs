// <Snippet51>
using System;
using System.IO;
using System.Threading.Tasks;

class Example
{
    public static void Main()
    {
        ReadAndDisplayFilesAsync();
    }

    private async static void ReadAndDisplayFilesAsync()
    {
        String filename = "TestFile1.txt";
        Char[] buffer;
        
        using (var sr = new StreamReader(filename)) {
            buffer = new Char[(int)sr.BaseStream.Length];
            await sr.ReadAsync(buffer, 0, (int)sr.BaseStream.Length);
        }

        Console.WriteLine(new String(buffer));
    }
}
// The example displays the following output:
//       This is the first line of text in a relatively short file.
//       This is the second line.
//       This is the third line.
//       This is the fourth and final line.
// </Snippet51>