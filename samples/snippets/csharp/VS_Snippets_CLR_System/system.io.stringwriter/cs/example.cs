// <Snippet1>
using System;
using System.Text;
using System.IO;

namespace ConsoleApplication
{
    class Program
    {
        static void Main(string[] args)
        {
            WriteCharacters();
        }

        static async void WriteCharacters()
        {
            StringBuilder stringToWrite = new StringBuilder("Characters in StringBuilder");
            stringToWrite.AppendLine();

            using (StringWriter writer = new StringWriter(stringToWrite))
            {
                await writer.WriteLineAsync("and add characters through StringWriter");
                Console.WriteLine(stringToWrite.ToString());
            }
        }
    }
}
// The example displays the following output:
//
// Characters in StringBuilder
// and add characters through StringWriter
//
// </Snippet1>