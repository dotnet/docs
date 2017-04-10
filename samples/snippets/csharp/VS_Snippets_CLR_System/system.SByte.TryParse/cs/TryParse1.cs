using System;

public class ParseSByte
{
   public static void Main()
   {
      // <Snippet1>
      string[] numericStrings = {"-3.6", "12.8", "+16.7", "    3   ", "(17)", 
                                 "-17", "+12", "18-", "987", "1,024", "  127 "};
      sbyte number;
      foreach (string numericString in numericStrings)
      {
         if (sbyte.TryParse(numericString, out number)) 
            Console.WriteLine("Converted '{0}' to {1}.", numericString, number);
         else
            Console.WriteLine("Cannot convert '{0}' to an SByte.", numericString);
      }
      // The example displays the following output to the console:
      //       Cannot convert '-3.6' to an SByte.
      //       Cannot convert '12.8' to an SByte.
      //       Cannot convert '+16.7' to an SByte.
      //       Converted '    3   ' to 3.
      //       Cannot convert '(17)' to an SByte.
      //       Converted '-17' to -17.
      //       Converted '+12' to 12.
      //       Cannot convert '18-' to an SByte.
      //       Cannot convert '987' to an SByte.
      //       Cannot convert '1,024' to an SByte.
      //       Converted '  127 ' to 127.
      // </Snippet1>
   }
}
