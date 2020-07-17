using System;

public class Example
{
   public static void Main()
   {
      // <Snippet1>
      double n = 123.8;
      Console.WriteLine($"{n:#,##0.0K}");
      // The example displays the following output:
      //      123.8K
      // </Snippet1>
   }
}
