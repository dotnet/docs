// <Snippet1>
using System;

class MyClass {

   static void Main() {
      object o = null;
      object p = null;
      object q = new Object();

      Console.WriteLine(Object.ReferenceEquals(o, p));
      p = q;
      Console.WriteLine(Object.ReferenceEquals(p, q));
      Console.WriteLine(Object.ReferenceEquals(o, p));
   }
}


/*

This code produces the following output.

True
True
False

*/
// </Snippet1>

