// <Snippet2>
using System;
using System.Collections;

public class Item3And4Comparer<T1, T2, T3, T4> : IEqualityComparer
{
   private int argument = 0;
   
   new public bool Equals(object x, object y)
   {
      argument++;
      
      // Return true for all values of Item1, Item2.
      if (argument <= 2)
         return true;
      else
         return x.Equals(y);
   }
   
   public int GetHashCode(object obj)
   {
      if (obj is T1)
         return ((T1) obj).GetHashCode();
      else if (obj is T2)
         return ((T2) obj).GetHashCode();
      else if (obj is T3)
         return ((T3) obj).GetHashCode();
      else
         return ((T4) obj).GetHashCode();
   }
}

public class Example
{
   public static void Main()
   {
      Tuple<string, int, double, double>[] temperatures = 
            { Tuple.Create("New York, NY", 4, 61.0, 43.0),
              Tuple.Create("Chicago, IL", 2, 34.0, 18.0), 
              Tuple.Create("Newark, NJ", 4, 61.0, 43.0),
              Tuple.Create("Boston, MA", 6, 77.0, 59.0),
              Tuple.Create("Detroit, MI", 9, 74.0, 53.0),
              Tuple.Create("Minneapolis, MN", 8, 81.0, 61.0) }; 
      // Compare each item with every other item for equality.
      for (int ctr = 0; ctr < temperatures.Length; ctr++)
      {
         IStructuralEquatable temperatureInfo = temperatures[ctr];
         for (int ctr2 = ctr + 1; ctr2 < temperatures.Length; ctr2++)
            Console.WriteLine("{0} = {1}: {2}", 
                              temperatureInfo, temperatures[ctr2], 
                              temperatureInfo.Equals(temperatures[ctr2], 
                                              new Item3And4Comparer<string, int, double, double>()));

         Console.WriteLine();                                               
      }
   }
}
// The example displays the following output:
//    (New York, NY, 4, 61, 43) = (Chicago, IL, 2, 34, 18): False
//    (New York, NY, 4, 61, 43) = (Newark, NJ, 4, 61, 43): True
//    (New York, NY, 4, 61, 43) = (Boston, MA, 6, 77, 59): False
//    (New York, NY, 4, 61, 43) = (Detroit, MI, 9, 74, 53): False
//    (New York, NY, 4, 61, 43) = (Minneapolis, MN, 8, 81, 61): False
//    
//    (Chicago, IL, 2, 34, 18) = (Newark, NJ, 4, 61, 43): False
//    (Chicago, IL, 2, 34, 18) = (Boston, MA, 6, 77, 59): False
//    (Chicago, IL, 2, 34, 18) = (Detroit, MI, 9, 74, 53): False
//    (Chicago, IL, 2, 34, 18) = (Minneapolis, MN, 8, 81, 61): False
//    
//    (Newark, NJ, 4, 61, 43) = (Boston, MA, 6, 77, 59): False
//    (Newark, NJ, 4, 61, 43) = (Detroit, MI, 9, 74, 53): False
//    (Newark, NJ, 4, 61, 43) = (Minneapolis, MN, 8, 81, 61): False
//    
//    (Boston, MA, 6, 77, 59) = (Detroit, MI, 9, 74, 53): False
//    (Boston, MA, 6, 77, 59) = (Minneapolis, MN, 8, 81, 61): False
//    
//    (Detroit, MI, 9, 74, 53) = (Minneapolis, MN, 8, 81, 61): False
// </Snippet2>