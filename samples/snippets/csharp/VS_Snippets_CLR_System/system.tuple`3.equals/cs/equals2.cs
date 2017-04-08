// <Snippet2>
using System;
using System.Collections;

public class Item2Comparer<T1, T2, T3> : IEqualityComparer
{
   new public bool Equals(object x, object y)
   {
      // Return true for all values of Item1.
      if (x is T1)
         return true;
      else if (x is T2)
         return x.Equals(y);
      else
         return true;	
   }
   
   public int GetHashCode(object obj)
   {
      if (obj is T1)
         return ((T1) obj).GetHashCode();
      else if (obj is T2)
         return ((T2) obj).GetHashCode();
      else
         return ((T3) obj).GetHashCode();
   }                
}

public class Example
{
   public static void Main()
   {
      Tuple<string, double, int>[] scores = 
           { Tuple.Create("Ed", 78.8, 8),
             Tuple.Create("Abbey", 92.1, 9), 
             Tuple.Create("Jim", 71.2, 9),
             Tuple.Create("Sam", 91.7, 8), 
             Tuple.Create("Sandy", 71.2, 5),
             Tuple.Create("Penelope", 82.9, 8),
             Tuple.Create("Serena", 71.2, 9),
             Tuple.Create("Judith", 84.3, 9) };

      for (int ctr = 0; ctr < scores.Length; ctr++)
      {
         IStructuralEquatable score = scores[ctr];
         for (int ctr2 = ctr + 1; ctr2 < scores.Length; ctr2++)
         {
            Console.WriteLine("{0} = {1}: {2}", score, 
                              scores[ctr2], 
                              score.Equals(scores[ctr2], 
                                           new Item2Comparer<string, double, int>()));
         }
         Console.WriteLine();
      }   
   }
}
// The example displays the following output:
//      (Ed, 78.8, 8) = (Abbey, 92.1, 9): False
//      (Ed, 78.8, 8) = (Jim, 71.2, 9): False
//      (Ed, 78.8, 8) = (Sam, 91.7, 8): False
//      (Ed, 78.8, 8) = (Sandy, 71.2, 5): False
//      (Ed, 78.8, 8) = (Penelope, 82.9, 8): False
//      (Ed, 78.8, 8) = (Serena, 71.2, 9): False
//      (Ed, 78.8, 8) = (Judith, 84.3, 9): False
//
//      (Abbey, 92.1, 9) = (Jim, 71.2, 9): False
//      (Abbey, 92.1, 9) = (Sam, 91.7, 8): False
//      (Abbey, 92.1, 9) = (Sandy, 71.2, 5): False
//      (Abbey, 92.1, 9) = (Penelope, 82.9, 8): False
//      (Abbey, 92.1, 9) = (Serena, 71.2, 9): False
//      (Abbey, 92.1, 9) = (Judith, 84.3, 9): False
//      
//      (Jim, 71.2, 9) = (Sam, 91.7, 8): False
//      (Jim, 71.2, 9) = (Sandy, 71.2, 5): True
//      (Jim, 71.2, 9) = (Penelope, 82.9, 8): False
//      (Jim, 71.2, 9) = (Serena, 71.2, 9): True
//      (Jim, 71.2, 9) = (Judith, 84.3, 9): False
//
//      (Sam, 91.7, 8) = (Sandy, 71.2, 5): False
//      (Sam, 91.7, 8) = (Penelope, 82.9, 8): False
//      (Sam, 91.7, 8) = (Serena, 71.2, 9): False
//      (Sam, 91.7, 8) = (Judith, 84.3, 9): False
//
//      (Sandy, 71.2, 5) = (Penelope, 82.9, 8): False
//      (Sandy, 71.2, 5) = (Serena, 71.2, 9): True
//      (Sandy, 71.2, 5) = (Judith, 84.3, 9): False
//
//      (Penelope, 82.9, 8) = (Serena, 71.2, 9): False
//      (Penelope, 82.9, 8) = (Judith, 84.3, 9): False
//
//      (Serena, 71.2, 9) = (Judith, 84.3, 9): False
// </Snippet2>