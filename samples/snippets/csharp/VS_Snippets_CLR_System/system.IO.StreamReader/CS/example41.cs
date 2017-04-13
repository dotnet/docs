// <Snippet41>
using System;
using System.IO;

namespace ConsoleApplication
{
    class Program
    {
        static void Main(string[] args)
        {
            ReadCharacters();
        }

        static async void ReadCharacters()
        {
            String result;
            using (StreamReader reader = File.OpenText("existingfile.txt"))
            {
                Console.WriteLine("Opened file.");
                result = await reader.ReadLineAsync();
                Console.WriteLine("First line contains: " + result);
            }
        }
    }
}
// </Snippet41>