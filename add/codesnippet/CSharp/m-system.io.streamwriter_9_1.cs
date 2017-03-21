using System;
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
            using (StreamWriter writer = File.CreateText("newfile.txt"))
            {
                await writer.WriteLineAsync('a');
                await writer.WriteLineAsync('b');
            }
        }
    }
}