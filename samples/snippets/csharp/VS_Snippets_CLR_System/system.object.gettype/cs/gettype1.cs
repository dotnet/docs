// <Snippet1>
using System;

public class Example
{
   public static void Main()
   {
      int n1 = 12;
      int n2 = 82;
      long n3 = 12;
      
      Console.WriteLine("n1 and n2 are the same type: {0}",
                        Object.ReferenceEquals(n1.GetType(), n2.GetType()));
      Console.WriteLine("n1 and n3 are the same type: {0}",
                        Object.ReferenceEquals(n1.GetType(), n3.GetType()));
   }
}
// The example displays the following output:
//       n1 and n2 are the same type: True
//       n1 and n3 are the same type: False      
// </Snippet1>
