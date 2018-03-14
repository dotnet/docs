// <Snippet24>
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
            UnicodeEncoding ue = new UnicodeEncoding();
            char[] charsToAdd = ue.GetChars(ue.GetBytes("Example string"));
            using (StreamWriter writer = File.CreateText("newfile.txt"))
            {
                await writer.WriteAsync(charsToAdd, 0, charsToAdd.Length);
            }
        }
    }
}
// </Snippet24>