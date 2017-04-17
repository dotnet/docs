using System;

public class Example
{
   public static void Main()
   {
      ShowFormattingCode();
      Console.WriteLine("---");
      ShowParsingCode();
   }

   private static void ShowFormattingCode()
   {
      // <Snippet1>
      TimeSpan interval = new TimeSpan(12, 30, 45);
      string output;
      try {
         output = String.Format("{0:r}", interval);
      }
      catch (FormatException) {
         output = "Invalid Format";
      }
      Console.WriteLine(output);
      // Output from .NET Framework 3.5 and earlier versions:
      //       12:30:45
      // Output from .NET Framework 4:
      //       Invalid Format
      // </Snippet1>   
   }
   
   private static void ShowParsingCode()
   {
      string value = "000000006";
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
}
