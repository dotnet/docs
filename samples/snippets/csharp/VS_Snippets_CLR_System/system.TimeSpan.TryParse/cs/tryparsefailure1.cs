using System;

public class Example
{
   public static void Main()
   {
      // <Snippet3>
      string value = "000000006";
      TimeSpan interval;
      if (TimeSpan.TryParse(value, out interval))
         Console.WriteLine("{0} --> {1}", value, interval);
      else
         Console.WriteLine("Unable to parse '{0}'", value);
      // Output from .NET Framework 3.5 and earlier versions:
      //       000000006 --> 6.00:00:00
      // Output from .NET Framework 4:
      //       Unable to parse //000000006//
      // </Snippet3>
   }
}
