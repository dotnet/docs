// <snippet8>
using System;
using System.IO;
using System.Text;

namespace ConsoleApplication
{
    class Program
    {
        static void Main(string[] args)
        {
            string fileName = "test.txt";
            string textToAdd = "Example text in file";

            
            using (StreamWriter writer = new StreamWriter(fileName, true, Encoding.UTF8, 512))
            {
                writer.Write(textToAdd);
            }
        }
    }
}
// </snippet8>
