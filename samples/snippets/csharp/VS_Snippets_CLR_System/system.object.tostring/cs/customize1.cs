// <Snippet7>
using System;
using System.Collections.Generic;

public class CList<T> : List<T>
{
   public CList(IEnumerable<T> collection) : base(collection)
   { }

   public CList() : base()
   {}

   public override String ToString()
   {
      String retVal = String.Empty;
      foreach (T item in this) {
         if (String.IsNullOrEmpty(retVal))
            retVal += item.ToString();
         else
            retVal += String.Format(", {0}", item);
      }
      return retVal;
   }
}

public class Example
{
   public static void Main()
   {
      var list2 = new CList<int>();
      list2.Add(1000);
      list2.Add(2000);
      Console.WriteLine(list2.ToString());
   }
}
// The example displays the following output:
//    1000, 2000
// </Snippet7>


