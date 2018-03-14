
// <Snippet1>
using System;
using System.Text;

public class Example  
{
   public static void Main()  
   {
      // Create two instances of UTF32Encoding: one with little-endian byte order and one with big-endian byte order.
      UTF32Encoding u32LE = new UTF32Encoding(false, true, true);
      UTF32Encoding u32BE = new UTF32Encoding(true, true, true);

      // Create byte arrays from the same string containing the following characters:
      //    Latin Small Letter Z (U+007A)
      //    Latin Small Letter A (U+0061)
      //    Combining Breve (U+0306)
      //    Latin Small Letter AE With Acute (U+01FD)
      //    Greek Small Letter Beta (U+03B2)
      String str = "za\u0306\u01FD\u03B2";

      // barrBE uses the big-endian byte order.
      byte[] barrBE = new byte[u32BE.GetByteCount(str)];
      u32BE.GetBytes(str, 0, str.Length, barrBE, 0);

      // barrLE uses the little-endian byte order.
      byte[] barrLE = new byte[u32LE.GetByteCount(str)];
      u32LE.GetBytes(str, 0, str.Length, barrLE, 0);

      // Decode the byte arrays.
      Console.WriteLine("BE array with BE encoding:");
      DisplayString(barrBE, u32BE);
      Console.WriteLine();

      Console.WriteLine("LE array with LE encoding:");
      DisplayString(barrLE, u32LE);
      Console.WriteLine();
   
      // Decode the byte arrays using an encoding with a different byte order.
      Console.WriteLine("BE array with LE encoding:");
      try  {
         DisplayString(barrBE, u32LE);
      }
      catch (System.ArgumentException e)  {
         Console.WriteLine(e.Message);
      }
      Console.WriteLine();

      Console.WriteLine("LE array with BE encoding:");
      try  {
         DisplayString(barrLE, u32BE);
      }
      catch (ArgumentException e)  {
         Console.WriteLine(e.Message);
      }
      Console.WriteLine();
   }

   public static void DisplayString(byte[] bytes, Encoding enc)  
   {
      // Display the name of the encoding used.
      Console.Write("{0,-25}: ", enc.ToString());

      // Decode the bytes and display the characters.
      Console.WriteLine(enc.GetString(bytes, 0, bytes.Length));
   }
}
// This example displays the following output:
//   BE array with BE encoding:
//   System.Text.UTF32Encoding: zăǽβ
//
//   LE array with LE encoding:
//   System.Text.UTF32Encoding: zăǽβ
//
//   BE array with LE encoding:
//   System.Text.UTF32Encoding: Unable to translate bytes [00][00][00][7A] at index 0 from specified code page to Unicode.
//
//   LE array with BE encoding:
//   System.Text.UTF32Encoding: Unable to translate bytes [7A][00][00][00] at index 0 from specified code page to Unicode.
// </Snippet1>





