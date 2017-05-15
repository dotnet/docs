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
            string fileName = "test.txt";
            string textToAdd = "Example text in file";
            FileStream fs = null;
            try
            {
               fs = new FileStream(fileName, FileMode.CreateNew);
               using (StreamWriter writer = new StreamWriter(fs, Encoding.Default))
                {
                    writer.Write(textToAdd);
                }
            }       
            finally
            {
                if (fs != null)
                    fs.Dispose();
            }
        }
    }
}
// </snippet2>
