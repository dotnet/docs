using System;

public class Example
{
   public static void Main()
   {


   }
}

// <Snippet9>
class A<T> {}

class B<T> : A<B<A<T>>> 
{}
// </Snippet9>
