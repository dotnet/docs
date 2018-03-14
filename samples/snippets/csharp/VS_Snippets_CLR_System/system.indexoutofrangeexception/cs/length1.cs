// <Snippet3>
using System;
using System.Collections.Generic;

public class Example
{
   public static void Main()
   {
      List<Char> characters = new List<Char>();
      characters.InsertRange(0, new Char[] { 'a', 'b', 'c', 'd', 'e', 'f' } );
      for (int ctr = 0; ctr <= characters.Count; ctr++)
         Console.Write("'{0}'    ", characters[ctr]);
   }
}
// The example displays the following output:
//    'a'    'b'    'c'    'd'    'e'    'f'
//    Unhandled Exception: 
//    System.ArgumentOutOfRangeException: 
//    Index was out of range. Must be non-negative and less than the size of the collection.
//    Parameter name: index
//       at Example.Main()
// </Snippet3>
