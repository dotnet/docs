using System;

public class Example
{
   public static void Main()
   {
      // <Snippet1>
      string[] numericStrings = { "1293.8", "+1671.7", "28347.", 
                                  "   33113  ", "(0)", "-0", "+12936", 
                                  "18-", "9870", "31,024", "  3127 ",  
                                  "70000" };
      ushort number;
      foreach (string numericString in numericStrings)
      {
         if (UInt16.TryParse(numericString, out number)) 
            Console.WriteLine("Converted '{0}' to {1}.", numericString, number);
         else
            Console.WriteLine("Cannot convert '{0}' to a UInt16.", numericString);
      }
      // The example displays the following output:
      //       Cannot convert '1293.8' to a UInt16.
      //       Cannot convert '+1671.7' to a UInt16.
      //       Cannot convert '28347.' to a UInt16.
      //       Converted '   33113  ' to 33113.
      //       Cannot convert '(0)' to a UInt16.
      //       Converted '-0' to 0.
      //       Converted '+12936' to 12936.
      //       Cannot convert '18-' to a UInt16.
      //       Converted '9870' to 9870.
      //       Cannot convert '31,024' to a UInt16.
      //       Converted '  3127 ' to 3127.
      //       Cannot convert '70000' to a UInt16.
      // </Snippet1>
   }
}
