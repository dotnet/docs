// <Snippet1>
using System;

public class Example
{
   public static void Main()
   {
      TimeSpan interval = new TimeSpan(12, 30, 45);
      string output;
      try {
         output = String.Format("{0:r}", interval);
      }
      catch (FormatException) {
         output = "Invalid Format";
      }
      Console.WriteLine(output);
   }
}
// </Snippet1>
