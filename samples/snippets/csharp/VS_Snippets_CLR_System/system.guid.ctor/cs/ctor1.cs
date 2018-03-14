// <Snippet1>
using System;

public class Example
{
   public static void Main()
   {
      string[] guidStrings = { "ca761232ed4211cebacd00aa0057b223",
                               "CA761232-ED42-11CE-BACD-00AA0057B223", 
                               "{CA761232-ED42-11CE-BACD-00AA0057B223}", 
                               "(CA761232-ED42-11CE-BACD-00AA0057B223)", 
                               "{0xCA761232, 0xED42, 0x11CE, {0xBA, 0xCD, 0x00, 0xAA, 0x00, 0x57, 0xB2, 0x23}}" };
      foreach (var guidString in guidStrings) {
         Guid guid = new Guid(guidString);
         Console.WriteLine("Original string: {0}", guidString);
         Console.WriteLine("Guid:            {0}", guid);
         Console.WriteLine();
      }
   }
}
// The example displays the following output:
//    Original string: ca761232ed4211cebacd00aa0057b223
//    Guid:            ca761232-ed42-11ce-bacd-00aa0057b223
//    
//    Original string: CA761232-ED42-11CE-BACD-00AA0057B223
//    Guid:            ca761232-ed42-11ce-bacd-00aa0057b223
//    
//    Original string: {CA761232-ED42-11CE-BACD-00AA0057B223}
//    Guid:            ca761232-ed42-11ce-bacd-00aa0057b223
//    
//    Original string: (CA761232-ED42-11CE-BACD-00AA0057B223)
//    Guid:            ca761232-ed42-11ce-bacd-00aa0057b223
//    
//    Original string: {0xCA761232, 0xED42, 0x11CE, {0xBA, 0xCD, 0x00, 0xAA, 0x00, 0x57, 0xB2, 0x23}}
//    Guid:            ca761232-ed42-11ce-bacd-00aa0057b223
// </Snippet1>