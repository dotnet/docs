using System;

public class Example
{
   public static void Main()
   {
      // <Snippet1>
      string[] numericStrings = { "1293.8", "+1671.7", "28347.",  
                                  "   33113684  ", "(0)", "-0", "-1", 
                                  "+1293617", "18-", "119870", "31,024", 
                                  "  3127094 ", "00700000" };
      uint number;
      foreach (string numericString in numericStrings)
      {
         if (UInt32.TryParse(numericString, out number)) 
            Console.WriteLine("Converted '{0}' to {1}.", numericString, number);
         else
            Console.WriteLine("Cannot convert '{0}' to a UInt32.", numericString);
      }
      // The example displays the following output:
      //       Cannot convert '1293.8' to a UInt32.
      //       Cannot convert '+1671.7' to a UInt32.
      //       Cannot convert '28347.' to a UInt32.
      //       Converted '   33113684  ' to 33113684.
      //       Cannot convert '(0)' to a UInt32.
      //       Converted '-0' to 0.
      //       Cannot convert '-1' to a UInt32.
      //       Converted '+1293617' to 1293617.
      //       Cannot convert '18-' to a UInt32.
      //       Converted '119870' to 119870.
      //       Cannot convert '31,024' to a UInt32.
      //       Converted '  3127094 ' to 3127094.
      //       Converted '0070000' to 70000.
      // </Snippet1>
   }
}
