using System;
using System.Collections.Generic;

public class Example
{
   public static void Main()
   {
      var list = new List<String>(); 
      list.AddRange( new String[] { "A", "B", "C" } );
      // <Snippet10>
      // Display each element in the list.
      foreach (var item in list) 
         Console.WriteLine("'{0}'", item);
      // </Snippet10> 
   }
}

