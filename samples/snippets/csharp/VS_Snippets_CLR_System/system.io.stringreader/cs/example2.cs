// <snippet2>
using System;
using System.IO;
using System.Text;

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
            StringBuilder stringToRead = new StringBuilder();
            stringToRead.AppendLine("Characters in 1st line to read");
            stringToRead.AppendLine("and 2nd line");
            stringToRead.AppendLine("and the end");

            using (StringReader reader = new StringReader(stringToRead.ToString()))
            {
                string readText = await reader.ReadToEndAsync();
                Console.WriteLine(readText);
            }
        }
    }
}
// The example displays the following output:
//
// Characters in 1st line to read
// and 2nd line
// and the end
//
// </snippet2>