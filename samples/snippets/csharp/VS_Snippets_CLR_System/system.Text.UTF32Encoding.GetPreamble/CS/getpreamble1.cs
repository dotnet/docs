// <Snippet2>
using System;
using System.IO;
using System.Text;

public class Example
{
   public static void Main()
   {
      String s = "This is a string to write to a file using UTF-32 encoding.";

      // Write a file using the default constructor without a BOM.
      var enc = new UTF32Encoding(! BitConverter.IsLittleEndian, false);
      Byte[] bytes = enc.GetBytes(s);
      WriteToFile(@".\NoPreamble.txt", enc, bytes);

      // Use BOM.
      enc = new UTF32Encoding(! BitConverter.IsLittleEndian, true);
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
//       Wrote 232 bytes to .\NoPreamble.txt.
//
//       Preamble has 4 bytes
//       Wrote 236 bytes to .\Preamble.txt.
// </Snippet2>
