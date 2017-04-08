// <Snippet25>
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
            char[] charsToAdd = ue.GetChars(ue.GetBytes("First line and second line"));
            using (StreamWriter writer = File.CreateText("newfile.txt"))
            {
                await writer.WriteLineAsync(charsToAdd, 0, 11);
                await writer.WriteLineAsync(charsToAdd, 11, charsToAdd.Length - 11);
            }
        }
    }
}
// </Snippet25>