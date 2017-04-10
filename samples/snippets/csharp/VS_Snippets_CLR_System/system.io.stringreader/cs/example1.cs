// <snippet1>
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
            string stringToRead = "Some characters to read but not all";
            char[] charsRead = new char[stringToRead.Length];

            using (StringReader reader = new StringReader(stringToRead))
            {
                await reader.ReadAsync(charsRead, 0, 23);
                Console.WriteLine(charsRead);
            }
        }
    }
}
// The example displays the following output:
// Some characters to read
//
// </snippet1>