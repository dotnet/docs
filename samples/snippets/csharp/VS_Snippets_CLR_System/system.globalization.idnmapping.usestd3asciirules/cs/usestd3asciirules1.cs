// <Snippet1>
using System;
using System.Globalization;

public class Example
{
   public static void Main()
   {
      int nFailed = 0;
      IdnMapping idnStd = new IdnMapping();
      idnStd.UseStd3AsciiRules = true;
      
      IdnMapping idnRelaxed = new IdnMapping();
      idnRelaxed.UseStd3AsciiRules = false;  // The default, but make it explicit.
      
      for (int ctr = 0; ctr <= 0x7F; ctr++) { 
         string name = "Prose" + Convert.ToChar(ctr) + "ware.com";
         
         bool stdFailed = false;
         bool relaxedFailed = false;
         string punyCode = "";
         try {
            punyCode = idnStd.GetAscii(name);
         }   
         catch (ArgumentException) {
            stdFailed = true;
         }       
         
         try {
            punyCode = idnRelaxed.GetAscii(name);
         }
         catch (ArgumentException) {
            relaxedFailed = true;
         }       
         
         if (relaxedFailed != stdFailed) {
            Console.Write("U+{0:X4}     ", ctr);
            nFailed++;
            if (nFailed % 5 == 0)
               Console.WriteLine();       
         }        
      }   
   }
}
// The example displays the following output:
//       U+0020     U+0021     U+0022     U+0023     U+0024
//       U+0025     U+0026     U+0027     U+0028     U+0029
//       U+002A     U+002B     U+002C     U+002F     U+003A
//       U+003B     U+003C     U+003D     U+003E     U+003F
//       U+0040     U+005B     U+005C     U+005D     U+005E
//       U+005F     U+0060     U+007B     U+007C     U+007D
//       U+007E
// </Snippet1>
