// <Snippet1>
using System;
using System.IO;
using System.Text;

public class Example
{
   public static void Main()
   {
      String s = "This is a string to write to a file using UTF-8 encoding.";

      // Write a file using the default constructor without a BOM.
      var enc = new UTF8Encoding();
      Byte[] bytes = enc.GetBytes(s);
      WriteToFile(@".\NoPreamble.txt", enc, bytes);

      // Use BOM.
      enc = new UTF8Encoding(true);
      WriteToFile(@".\Preamble.txt", enc, bytes);
   }

   private static void WriteToFile(String fn, Encoding enc, Byte[] bytes)
   {
      var fs = new FileStream(fn, FileMode.Create);
      Byte[] preamble = enc.GetPreamble();
      fs.Write(preamble, 0, preamble.Length);
      Console.WriteLine("Preamble has {0} bytes", preamble.Length);
      fs.Write(bytes, 0, bytes.Length);
      Console.WriteLine("Wrote {0} bytes to {1}.", fs.Length, fn);
      fs.Close();
      Console.WriteLine();
   }
}
// The example displays the following output:
//       Preamble has 0 bytes
//       Wrote 57 bytes to NoPreamble.txt.
//
//       Preamble has 3 bytes
//       Wrote 60 bytes to Preamble.txt.
// </Snippet1>
