// <Snippet4>
using System;
using System.Collections.Generic;

public class Example
{
   public static void Main()
   {
      List<Char> characters = new List<Char>();
      characters.InsertRange(0, new Char[] { 'a', 'b', 'c', 'd', 'e', 'f' } );
      for (int ctr = 0; ctr < characters.Count; ctr++)
         Console.Write("'{0}'    ", characters[ctr]);
   }
}
// The example displays the following output:
//        'a'    'b'    'c'    'd'    'e'    'f'
// </Snippet4>
