// <Snippet1>
using System;
using System.Text;

public class Example
{
   public static void Main()
   {
      UTF8Encoding utf8 = new UTF8Encoding(true, true);

      String s = "It was the best of times, it was the worst of times...";

      // We need to dimension the array, since we'll populate it with 2 method calls.
      Byte[] bytes = new Byte[utf8.GetByteCount(s) + utf8.GetPreamble().Length];
      // Encode the string.
      Array.Copy(utf8.GetPreamble(), bytes, utf8.GetPreamble().Length);
      utf8.GetBytes(s, 0, s.Length, bytes, utf8.GetPreamble().Length);

      // Decode the byte array.
      String s2 = utf8.GetString(bytes, 0, bytes.Length);
      Console.WriteLine(s2);
   }
}
// The example displays the following output:
//        ?It was the best of times, it was the worst of times...
// </Snippet1>

