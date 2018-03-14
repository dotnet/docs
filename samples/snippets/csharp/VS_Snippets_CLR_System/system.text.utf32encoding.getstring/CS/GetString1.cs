// <Snippet2>
using System;
using System.Text;

public class Example
{
   public static void Main()
   {
      var utf32 = new UTF32Encoding(! BitConverter.IsLittleEndian, true);

      String s = "It was the best of times, it was the worst of times...";

      // We need to dimension the array, since we'll populate it with 2 method calls.
      Byte[] bytes = new Byte[utf32.GetByteCount(s) + utf32.GetPreamble().Length];
      // Encode the string.
      Array.Copy(utf32.GetPreamble(), bytes, utf32.GetPreamble().Length);
      utf32.GetBytes(s, 0, s.Length, bytes, utf32.GetPreamble().Length);

      // Decode the byte array.
      String s2 = utf32.GetString(bytes, 0, bytes.Length);
      Console.WriteLine(s2);
   }
}
// The example displays the following output:
//        ?It was the best of times, it was the worst of times...
// </Snippet2>

