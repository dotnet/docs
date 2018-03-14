// <Snippet1>
using System;

public class Example
{
   public static void Main()
   {
      int int1 = 3;
      Console.WriteLine(Object.ReferenceEquals(int1, int1));
      Console.WriteLine(int1.GetType().IsValueType);
   }
}
// The example displays the following output:
//       False
//       True
// </Snippet1>
