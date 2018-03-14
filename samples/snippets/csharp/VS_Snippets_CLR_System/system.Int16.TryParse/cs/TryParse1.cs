// <Snippet1>
using System;

public class StringParsing
{
   public static void Main()
   {
      TryToParse(null);
      TryToParse("16051");
      TryToParse("9432.0");
      TryToParse("16,667");
      TryToParse("   -322   ");
      TryToParse("+4302");
      TryToParse("(100);");
      TryToParse("01FA");
   }

   private static void TryToParse(string value)
   {
      short number;
      bool result = Int16.TryParse(value, out number);
      if (result)
      {
         Console.WriteLine("Converted '{0}' to {1}.", value, number);         
      }
      else
      {
         if (value == null) value = ""; 
         Console.WriteLine("Attempted conversion of '{0}' failed.", value);
      }
   }
}
// The example displays the following output to the console:
//       Attempted conversion of '' failed.
//       Converted '16051' to 16051.
//       Attempted conversion of '9432.0' failed.
//       Attempted conversion of '16,667' failed.
//       Converted '   -322   ' to -322.
//       Converted '+4302' to 4302.
//       Attempted conversion of '(100)' failed.
//       Attempted conversion of '01FA' failed.
// </Snippet1>
