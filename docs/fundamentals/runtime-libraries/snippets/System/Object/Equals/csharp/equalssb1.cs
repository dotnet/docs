// <Snippet5>
using System;
using System.Text;

public class Example5
{
   public static void Main()
   {
      StringBuilder sb1 = new StringBuilder("building a string...");
      StringBuilder sb2 = new StringBuilder("building a string...");

      Console.WriteLine($"sb1.Equals(sb2): {sb1.Equals(sb2)}");
      Console.WriteLine($"((Object) sb1).Equals(sb2): {((Object) sb1).Equals(sb2)}");
      Console.WriteLine($"Object.Equals(sb1, sb2): {Object.Equals(sb1, sb2)}");

      Object sb3 = new StringBuilder("building a string...");
      Console.WriteLine($"\nsb3.Equals(sb2): {sb3.Equals(sb2)}");
   }
}
// The example displays the following output:
//       sb1.Equals(sb2): True
//       ((Object) sb1).Equals(sb2): False
//       Object.Equals(sb1, sb2): False
//
//       sb3.Equals(sb2): False
// </Snippet5>
