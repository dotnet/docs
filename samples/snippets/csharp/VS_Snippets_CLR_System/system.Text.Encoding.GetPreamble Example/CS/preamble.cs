//<snippet1>
using System;
using System.Text;

namespace GetPreambleExample
{
   class GetPreambleExampleClass
   {
      static void Main()
      {
         Encoding unicode = Encoding.Unicode;

         // Get the preamble for the Unicode encoder. 
         // In this case the preamble contains the byte order mark (BOM).
         byte[] preamble = unicode.GetPreamble();

         // Make sure a preamble was returned 
         // and is large enough to containa BOM.
         if(preamble.Length >= 2)
         {
            if(preamble[0] == 0xFE && preamble[1] == 0xFF)
            {
               Console.WriteLine("The Unicode encoder is encoding in big-endian order.");
            }
            else if(preamble[0] == 0xFF && preamble[1] == 0xFE)
            {
               Console.WriteLine("The Unicode encoder is encoding in little-endian order.");
            }
         }
      }
   }
}

/*
This code produces the following output.

The Unicode encoder is encoding in little-endian order.

*/
//</snippet1>
