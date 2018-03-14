// <Snippet1>
using System;

public class Example
{
   public static void Main()
   {
      var doubleTuple1 = Tuple.Create(12.3455);
      var doubleTuple2 = Tuple.Create(16.8912);
      var doubleTuple3 = Tuple.Create(12.3455);
      var singleTuple1 = Tuple.Create(12.3455f);
      var tuple2 = Tuple.Create("James", 97.3); 
        
      // Compare first tuple with a Tuple(Of Double) with a different value.
      TestEquality(doubleTuple1, doubleTuple2);
      // Compare first tuple with a Tuple(Of Double) with the same value.
      TestEquality(doubleTuple1, doubleTuple3);
      // Compare first tuple with a Tuple(Of Single) with the same value.
      TestEquality(doubleTuple1, singleTuple1);
      // Compare a 1-tuple with a 2-tuple.
      TestEquality(doubleTuple1, tuple2); 
   }

   private static void TestEquality(Tuple<double> tuple, object obj)
   {
      Console.WriteLine("{0} = {1}: {2}", tuple.ToString(),
                                          obj.ToString(),
                                          tuple.Equals(obj));
   } 
}
// The example displays the following output:
//       (12.3455) = (16.8912): False
//       (12.3455) = (12.3455): True
//       (12.3455) = (12.3455): False
//       (12.3455) = (James, 97.3): False
// </Snippet1>