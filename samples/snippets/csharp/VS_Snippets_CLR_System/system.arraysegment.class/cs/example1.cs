// <Snippet1>
using System;
using System.Collections.Generic;

public class Example
{
   public static void Main()
   {
      String[] names = { "Adam", "Bruce", "Charles", "Daniel", 
                         "Ebenezer", "Francis", "Gilbert", 
                         "Henry", "Irving", "John", "Karl",
                         "Lucian", "Michael" };
      var partNames = new ArraySegment<String>(names, 2, 5);
      
      // Cast the ArraySegment object to an IList<String> and enumerate it.
      var list = (IList<String>) partNames;
      for (int ctr = 0; ctr <= list.Count - 1; ctr++)
         Console.WriteLine(list[ctr]);
   }
}
// The example displays the following output:
//    Charles
//    Daniel
//    Ebenezer
//    Francis
//    Gilbert
// </Snippet1>