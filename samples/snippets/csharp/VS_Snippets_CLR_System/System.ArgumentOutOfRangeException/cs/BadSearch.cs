// <Snippet6>
using System;
using System.Collections.Generic;

public class Example
{
   public static void Main()
   {
      var list = new List<String>(); 
      list.AddRange( new String[] { "A", "B", "C" } );
      // Get the index of the element whose value is "Z".
      int index = list.FindIndex((new StringSearcher("Z")).FindEquals);
      try {
         Console.WriteLine("Index {0} contains '{1}'", index, list[index]); 
      }
      catch (ArgumentOutOfRangeException e) {
         Console.WriteLine(e.Message);
      }
   }
}

internal class StringSearcher
{
   String value;
   
   public StringSearcher(String value)
   {
      this.value = value;
   }
   
   public bool FindEquals(String s) 
   {
      return s.Equals(value, StringComparison.InvariantCulture); 
   }
}
// The example displays the following output:
//   Index was out of range. Must be non-negative and less than the size of the collection.
//   Parameter name: index
// </Snippet6>

public class Example2
{
   public static void Test()
   {
      var list = new List<String>(); 
      list.AddRange( new String[] { "A", "B", "C" } );
      // <Snippet7>
      // Get the index of the element whose value is "Z".
      int index = list.FindIndex((new StringSearcher("Z")).FindEquals);
      if (index >= 0)
         Console.WriteLine("'Z' is found at index {0}", list[index]); 
      // </Snippet7>
   }
}
