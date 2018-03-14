// <Snippet8>
using System;

struct N<T> {}
struct X { N<X> x; }

public class Example
{
   public static void Main()
   {
      N<int> n = new N<int>();
      X x = new X();
   }
}
// </Snippet8>
