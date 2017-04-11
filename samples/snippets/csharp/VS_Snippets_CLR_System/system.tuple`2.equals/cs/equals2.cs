// <Snippet2>
using System;
using System.Collections;

public class Item2Comparer<T1, T2> : IEqualityComparer
{
   new public bool Equals(object x, object y)
   {
      // Return true for all values of Item1.
      if (x is T1)
      //if (typeof(x) is string) 
         return true;
      else
         return x.Equals(y);
   }
   
   public int GetHashCode(object obj)
   {
      if (obj is T1)
         return ((T1) obj).GetHashCode();
      else
         return ((T2) obj).GetHashCode();
   }                
}

public class Example
{
   public static void Main()
   {
      Tuple<string, double>[] distancesWalked = {
                        Tuple.Create("Jan", Double.NaN), 
                        Tuple.Create("Joe", Double.NaN), 
                        Tuple.Create("Adam", 1.36), 
                        Tuple.Create("Selena", 2.01),
                        Tuple.Create("Jake", 1.36) };
      for (int ctr = 0; ctr < distancesWalked.Length; ctr++)
      {
         Tuple<string, double> distanceWalked = distancesWalked[ctr];
         for (int ctr2 = ctr + 1; ctr2 < distancesWalked.Length; ctr2++)
         {
            Console.WriteLine("{0} = {1}: {2}", distanceWalked, 
                              distancesWalked[ctr2], 
                              ((IStructuralEquatable)distanceWalked).Equals(distancesWalked[ctr2], 
                                                    new Item2Comparer<string, double>()));
         }
         Console.WriteLine();
      }   
   }
}
// The example displays the following output:
//       (Jan, NaN) = (Joe, NaN): True
//       (Jan, NaN) = (Adam, 1.36): False
//       (Jan, NaN) = (Selena, 2.01): False
//       (Jan, NaN) = (Jake, 1.36): False
//       
//       (Joe, NaN) = (Adam, 1.36): False
//       (Joe, NaN) = (Selena, 2.01): False
//       (Joe, NaN) = (Jake, 1.36): False
//       
//       (Adam, 1.36) = (Selena, 2.01): False
//       (Adam, 1.36) = (Jake, 1.36): True
//       
//       (Selena, 2.01) = (Jake, 1.36): False
// </Snippet2>