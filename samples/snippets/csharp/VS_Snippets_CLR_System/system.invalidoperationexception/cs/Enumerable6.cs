// <Snippet11>
using System;
using System.Linq;

public class Example
{
   public static void Main()
   {
       int[] dbQueryResults = { 1, 2, 3, 4 };
   
       var singleObject = dbQueryResults.SingleOrDefault(value => value > 2);
   
       if (singleObject != 0)
           Console.WriteLine("{0} is the only value greater than 2", 
                             singleObject);
       else
           // Handle an empty collection.
           Console.WriteLine("No value is greater than 2");
   }
}
// The example displays the following output:
//    Unhandled Exception: System.InvalidOperationException: 
//       Sequence contains more than one matching element
//       at System.Linq.Enumerable.SingleOrDefault[TSource](IEnumerable`1 source, Func`2 predicate)
//       at Example.Main()
// </Snippet11>


