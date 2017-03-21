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