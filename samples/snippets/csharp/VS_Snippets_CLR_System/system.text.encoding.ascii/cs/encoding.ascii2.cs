// <Snippet1>
using System;
using System.Text;

public class Example
{
   public static void Main()
   {
      Encoding enc = Encoding.GetEncoding("us-ascii", 
                                          new EncoderExceptionFallback(),
                                          new DecoderExceptionFallback());
      string value = "\u00C4 \u00F6 \u00AE"; 
      
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
//        Unable to encode U+00C4 at index 0
// </Snippet1>
