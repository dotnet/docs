// <Snippet2>
using System;
using System.Collections;

public class DoubleComparer<T1, T2, T3, T4, T5> : IEqualityComparer
{
   private double difference;
   private int argument = 0;
   
   public DoubleComparer(double difference)
   {
      this.difference = difference;
   }
   
   new public bool Equals(object x, object y)
   { 
      argument += 1;
      
      // Return true for Item1.
      if (argument == 1) return true;

      double d1 = (double) x;
      double d2 = (double) y;

      if (d1 - d2 < d1 * difference)
         return true;
      else            
         return false;
   }
   
   public int GetHashCode(object obj)
   {
      if (obj is T1)
         return ((T1) obj).GetHashCode();
      else if (obj is T2)
         return ((T2) obj).GetHashCode();
      else if (obj is T3)
         return ((T3) obj).GetHashCode();
      else if (obj is T4)
         return ((T4) obj).GetHashCode();
      else
         return ((T5) obj).GetHashCode();   
   }
}

public class Example
{
   public static void Main()
   {
      var value1 = GetValues(1);
      var value2 = GetValues(2);
      IStructuralEquatable iValue1 = value1;
      Console.WriteLine("{0} =\n{1} :\n{2}", value1, value2, 
                        iValue1.Equals(value2, 
                        new DoubleComparer<int, double, double, double, double>(.01)));
   }

   private static Tuple<int, double, double, double, double> GetValues(int ctr)
   {
      // Generate four random numbers between 0 and 1
      Random rnd = new Random((int)DateTime.Now.Ticks >> 32 >> ctr);
      return Tuple.Create(ctr, rnd.NextDouble(), rnd.NextDouble(), 
                          rnd.NextDouble(), rnd.NextDouble());
   }                                   
}
// </Snippet2>