using System;

public class Example
{
   public static void Main()
   {
      // <Snippet1>
      short[] values= { Int16.MinValue, -27, 0, 1042, Int16.MaxValue };
      Console.WriteLine("{0,10}  {1,10}\n", "Decimal", "Hex");
      foreach (short value in values)
      {
         string formatString = String.Format("{0,10:G}: {0,10:X}", value);
         Console.WriteLine(formatString);
      }   
      // The example displays the following output:
      //       Decimal         Hex
      //    
      //        -32768:       8000
      //           -27:       FFE5
      //             0:          0
      //          1042:        412
      //         32767:       7FFF
      // </Snippet1>
   }
}
