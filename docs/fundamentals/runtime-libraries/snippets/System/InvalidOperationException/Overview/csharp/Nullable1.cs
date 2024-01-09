// <Snippet4>
using System;
using System.Linq;

public class NullableEx1
{
   public static void Main()
   {
      var queryResult = new int?[] { 1, 2, null, 4 };
      var map = queryResult.Select(nullableInt => (int)nullableInt);

      // Display list.
      foreach (var num in map)
         Console.Write("{0} ", num);
      Console.WriteLine();
   }
}
// The example displays the following output:
//    1 2
//    Unhandled Exception: System.InvalidOperationException: Nullable object must have a value.
//       at System.ThrowHelper.ThrowInvalidOperationException(ExceptionResource resource)
//       at Example.<Main>b__0(Nullable`1 nullableInt)
//       at System.Linq.Enumerable.WhereSelectArrayIterator`2.MoveNext()
//       at Example.Main()
// </Snippet4>
