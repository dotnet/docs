// <Snippet2>
using System;
using System.Collections;

public class Tuple1Comparer : IEqualityComparer
{
   new public bool Equals(object x, object y)
   {
      // Check if x is a floating point type. If x is, then y is.
      if (x is double | x is float)
      {   
         // Convert to Double values.
         double dblX = (double) x;
         double dblY = (double) y;
         if (Double.IsNaN(dblX) | Double.IsInfinity(dblX) |
             Double.IsNaN(dblY) | Double.IsInfinity(dblY)) 
            return dblX.Equals(dblY);   
         else
            return Math.Abs(dblX - dblY) <= dblX * .0001;
      }
      else
      {
         return x.Equals(y);
      }
   }
   
   public int GetHashCode(object obj)
   {
      return obj.GetHashCode();
   }
}

public class Example
{
   public static void Main()
   {
      var doubleTuple1 = Tuple.Create(12.3455);

      var doubleTuple2 = Tuple.Create(16.8912);
      var doubleTuple3 = Tuple.Create(12.3449599);

      // Compare first tuple with a Tuple<double> with a different value.
      TestEquality(doubleTuple1, doubleTuple2);
      //Compare first tuple with a Tuple<double> with the same value.
      TestEquality(doubleTuple1, doubleTuple3);
   }

   private static void TestEquality(Tuple<double> tuple, object obj)
   {
      Console.WriteLine("{0} = {1}: {2}", tuple.ToString(),
                                             obj.ToString(),
                                             ((IStructuralEquatable)tuple).Equals(obj, new Tuple1Comparer()));
   }
}
// The example displays the following output:
//       (12.3455) = (16.8912): False
//       (12.3455) = (12.3449599): True
// </Snippet2>