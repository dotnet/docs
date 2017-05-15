// <Snippet1>
using System;
using System.Collections;
using System.Collections.Generic;

public class NanComparer : IEqualityComparer
{
   public new bool Equals(object x, object y)
   {
      if (x is float)
         return (float) x == (float) y;
      else if (x is double)
         return (double) x == (double) y;
      else
         return EqualityComparer<object>.Default.Equals(x, y);
   }
   
   public int GetHashCode(object obj)
   {
      return EqualityComparer<object>.Default.GetHashCode(obj);
   }
}
// </Snippet1>

// <Snippet2>
public class Example
{
   public static void Main()
   {
      var t1 = Tuple.Create(12.3, Double.NaN, 16.4);
      var t2 = Tuple.Create(12.3, Double.NaN, 16.4);
      
      // Call default Equals method.
      Console.WriteLine(t1.Equals(t2));
      
      IStructuralEquatable equ = t1;
      // Call IStructuralEquatable.Equals using default comparer.
      Console.WriteLine(equ.Equals(t2, EqualityComparer<object>.Default));
      
      // Call IStructuralEquatable.Equals using 
      // StructuralComparisons.StructuralEqualityComparer.
      Console.WriteLine(equ.Equals(t2, 
                        StructuralComparisons.StructuralEqualityComparer));
      
      // Call IStructuralEquatable.Equals using custom comparer.
      Console.WriteLine(equ.Equals(t2, new NanComparer()));
   }
}
// The example displays the following output:
//       True
//       True
//       True
//       False
// </Snippet2>