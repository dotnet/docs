// <Snippet8>
using System;
using System.Collections.Generic;

public class Example
{
   public static void Main()
   {
      var list = new List<String>(); 
      list.AddRange( new String[] { "A", "B", "C" } );
      try {
         // Display the elements in the list by index.
         for (int ctr = 0; ctr <= list.Count; ctr++) 
            Console.WriteLine("Index {0}: {1}", ctr, list[ctr]);
      } 
      catch (ArgumentOutOfRangeException e) {
         Console.WriteLine(e.Message);
      }
   }
}
// The example displays the following output:
//   Index 0: A
//   Index 1: B
//   Index 2: C
//   Index was out of range. Must be non-negative and less than the size of the collection.
//   Parameter name: index
// </Snippet8>

public class Example2
{
   public static void Test()
   {
      var list = new List<String>(); 
      list.AddRange( new String[] { "A", "B", "C" } );
      // <Snippet9>
      // Display the elements in the list by index.
      for (int ctr = 0; ctr < list.Count; ctr++) 
         Console.WriteLine("Index {0}: {1}", ctr, list[ctr]);
      // </Snippet9> 
   }
}

