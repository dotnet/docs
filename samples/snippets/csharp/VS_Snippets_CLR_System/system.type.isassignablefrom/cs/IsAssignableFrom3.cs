// <Snippet3>
using System;
using System.Collections;

public class Example
{
   public static void Main()
   {
      Type t = typeof(IEnumerable);
      Type c = typeof(Array);
      
      IEnumerable instanceOfT;
      int[] instanceOfC = { 1, 2, 3, 4 };
      if (t.IsAssignableFrom(c))
         // <Snippet4>
         instanceOfT = instanceOfC;
         // </Snippet4>
  }
}
// </Snippet3>
