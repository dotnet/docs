// <Snippet1>
using System;
using System.Globalization;

public class Example
{
   public static void Main()
   {
      var name = "Bartholomew";
      FormattableString s3 = $"Hello, {name}!";  
      Console.WriteLine($"String: {s3.Format}");
      Console.WriteLine($"Arguments: {s3.ArgumentCount}");
      Console.WriteLine($"Result string: {s3}");
   }
}
// The example displays the following output:
//       String: Hello, {0}!
//       Arguments: 1
//       Result string: Hello, Bartholomew!
// </Snippet1>

