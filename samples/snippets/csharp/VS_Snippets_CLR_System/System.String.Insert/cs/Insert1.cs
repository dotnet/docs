// <Snippet1>
using System;

public class Example
{
   public static void Main()
   {
      String original = "aaabbb";
      Console.WriteLine("The original string: '{0}'", original);
      String modified = original.Insert(3, " ");
      Console.WriteLine("The modified string: '{0}'", modified);
   }
}
// The example displays the following output:
//     The original string: 'aaabbb'
//     The modified string: 'aaa bbb'
// </Snippet1>


