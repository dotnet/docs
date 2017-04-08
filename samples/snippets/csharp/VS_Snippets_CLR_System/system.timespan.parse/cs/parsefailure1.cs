using System;

public class Example
{
   public static void Main()
   {
      // <Snippet3>
      string[] values = { "000000006", "12.12:12:12.12345678" };
      foreach (string value in values)
      {
         try {
            TimeSpan interval = TimeSpan.Parse(value);
            Console.WriteLine("{0} --> {1}", value, interval);
         }   
         catch (FormatException) {
            Console.WriteLine("{0}: Bad Format", value);
         }   
         catch (OverflowException) {
            Console.WriteLine("{0}: Overflow", value);
         }
      }
      // Output from .NET Framework 3.5 and earlier versions:
      //       000000006 --> 6.00:00:00
      //       12.12:12:12.12345678: Bad Format      
      // Output from .NET Framework 4:
      //       000000006: Overflow
      //       12.12:12:12.12345678: Overflow
      // </Snippet3>
   }
}
