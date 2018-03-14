// <Snippet1>
using System;
using System.IO;

namespace BigEndianExample
{
   public class Class1 
   {
      public static void Main(string[] args) 
      {
         // Read a text file saved with Big Endian Unicode encoding.
         System.Text.Encoding encoding = System.Text.Encoding.BigEndianUnicode;
         StreamReader reader = new StreamReader("TextFile.txt", encoding);
         string line = reader.ReadLine();
         while (line != null) 
         {
            Console.WriteLine(line);
            line = reader.ReadLine();
         }
       }
    }
}
// </Snippet1>
