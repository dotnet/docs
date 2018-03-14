// <Snippet4>
using System;

public class Example
{
   public static void Main()
   {
      char[] characters = { 'a', 'b', 'c', 'd', 'e', 'f' };
      object[][] arguments = new object[3][] { new object[] { characters },
                                               new object[] { characters, 1, 4 },
                                               new object[] { characters[1], 20 } };

      for (int ctr = 0; ctr <= arguments.GetUpperBound(0); ctr++) {
         object[] args = arguments[ctr];
         object result = Activator.CreateInstance(typeof(String), args);
         Console.WriteLine("{0}: {1}", result.GetType().Name, result);
      }
   }
}
// The example displays the following output:
//    String: abcdef
//    String: bcde
//    String: bbbbbbbbbbbbbbbbbbbb
// </Snippet4>