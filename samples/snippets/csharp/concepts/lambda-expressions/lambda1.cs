// <Snippet1>
using System;

class Example
{
   public static void Main()
   {
      Func<int, int> square = x => x * x; 
      Console.WriteLine(square(25));
   }
}
// The example displays the following output:
//      625
// </Snippet1>

