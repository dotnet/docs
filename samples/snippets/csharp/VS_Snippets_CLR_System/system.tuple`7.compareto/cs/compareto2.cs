// <Snippet2>
using System;
using System.Collections;
using System.Collections.Generic;

public class PopulationComparer<T1, T2, T3, T4, T5, T6, T7> : IComparer
{
   private int itemPosition;
   private int multiplier = -1;

   public PopulationComparer(int component) : this(component, true)
   { }

   public PopulationComparer(int component, bool descending)
   {
      if (! descending) multiplier = 1;

      if (component <= 0 || component > 7)
         throw new ArgumentException("The component argument is out of range.");

      itemPosition = component;
   }

   public int Compare(object x, object y)
   {
      Tuple<T1, T2, T3, T4, T5, T6, T7> tX = x as Tuple<T1, T2, T3, T4, T5, T6, T7>;
      if (tX == null)
      {
         return 0;
      }
      else
      {
         Tuple<T1, T2, T3, T4, T5, T6, T7> tY = y as Tuple<T1, T2, T3, T4, T5, T6, T7>;
         switch (itemPosition)
         {
            case 1:
               return Comparer<T1>.Default.Compare(tX.Item1, tY.Item1) * multiplier;
            case 2:
               return Comparer<T2>.Default.Compare(tX.Item2, tY.Item2) * multiplier;
            case 3:
               return Comparer<T3>.Default.Compare(tX.Item3, tY.Item3) * multiplier;
            case 4:
               return Comparer<T4>.Default.Compare(tX.Item4, tY.Item4) * multiplier;
            case 5:
               return Comparer<T5>.Default.Compare(tX.Item5, tY.Item5) * multiplier;
            case 6:
               return Comparer<T6>.Default.Compare(tX.Item6, tY.Item6) * multiplier;
            case 7:
               return Comparer<T7>.Default.Compare(tX.Item7, tY.Item7) * multiplier;
            default:
               return Comparer<T1>.Default.Compare(tX.Item1, tY.Item1) * multiplier;
         }
      }
   }
}

public class Example
{
   public static void Main()
   {
      // Create array of sextuple with population data for three U.S.
      // cities, 1960-2000.
      Tuple<string, int, int, int, int, int, int>[] cities =
           { Tuple.Create("Los Angeles", 1970358, 2479015, 2816061, 2966850, 3485398, 3694820),
             Tuple.Create("New York", 7891957, 7781984, 7894862, 7071639, 7322564, 8008278),
             Tuple.Create("Chicago", 3620962, 3550904, 3366957, 3005072, 2783726, 2896016) };

      // Display array in unsorted order.
      Console.WriteLine("In unsorted order:");
      foreach (var city in cities)
         Console.WriteLine(city.ToString());
      Console.WriteLine();

      Array.Sort(cities, new PopulationComparer<string, int, int, int, int, int, int>(3));

      // Display array in sorted order.
      Console.WriteLine("Sorted by population in 1960:");
      foreach (var city in cities)
         Console.WriteLine(city.ToString());
      Console.WriteLine();

      Array.Sort(cities, new PopulationComparer<string, int, int, int, int, int, int>(6));

      // Display array in sorted order.
      Console.WriteLine("Sorted by population in 1990:");
      foreach (var city in cities)
         Console.WriteLine(city.ToString());
   }
}
// The example displays the following output:
//    In unsorted order:
//    (Los Angeles, 1970358, 2479015, 2816061, 2966850, 3485398, 3694820)
//    (New York, 7891957, 7781984, 7894862, 7071639, 7322564, 8008278)
//    (Chicago, 3620962, 3550904, 3366957, 3005072, 2783726, 2896016)
//    
//    Sorted by population in 1960:
//    (New York, 7891957, 7781984, 7894862, 7071639, 7322564, 8008278)
//    (Chicago, 3620962, 3550904, 3366957, 3005072, 2783726, 2896016)
//    (Los Angeles, 1970358, 2479015, 2816061, 2966850, 3485398, 3694820)
//    
//    Sorted by population in 1990:
//    (New York, 7891957, 7781984, 7894862, 7071639, 7322564, 8008278)
//    (Los Angeles, 1970358, 2479015, 2816061, 2966850, 3485398, 3694820)
//    (Chicago, 3620962, 3550904, 3366957, 3005072, 2783726, 2896016)
// </Snippet2>
