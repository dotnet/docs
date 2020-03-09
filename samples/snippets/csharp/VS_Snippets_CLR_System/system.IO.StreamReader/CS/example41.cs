// <Snippet41>
using System;
using System.IO;

namespace ConsoleApplication
{
    class Program
    {
        static async Task Main()
        {
            await ReadCharacters();
        }

        static async Task ReadCharacters()
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
