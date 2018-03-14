// <Snippet1>
using System;
using System.Text;

public class Example
{
   public static void Main()
   {
      Encoding enc = new UTF32Encoding(false, true, true);
      string value = "\u00C4 \uD802\u0033 \u00AE"; 

      try {
         byte[] bytes= enc.GetBytes(value);
         foreach (var byt in bytes)
            Console.Write("{0:X2} ", byt);
         Console.WriteLine();

         string value2 = enc.GetString(bytes);
         Console.WriteLine(value2);
      }
      catch (EncoderFallbackException e) {
         Console.WriteLine("Unable to encode {0} at index {1}", 
                           e.IsUnknownSurrogate() ? 
                              String.Format("U+{0:X4} U+{1:X4}", 
                                            Convert.ToUInt16(e.CharUnknownHigh),
                                            Convert.ToUInt16(e.CharUnknownLow)) :
                              String.Format("U+{0:X4}", 
                                            Convert.ToUInt16(e.CharUnknown)),
                           e.Index);
      }                     
   }
}
// The example displays the following output:
//        Unable to encode U+D802 at index 2
// </Snippet1>

