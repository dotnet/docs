// <Snippet2>
using System;
using System.Collections;

public class RateComparer<T1, T2, T3, T4, T5, T6> : IEqualityComparer
{
   private int argument = 0;

   public new bool Equals(object x, object y) 
   {
      argument++;
      if (argument == 1) return true;

      double fx, fy; 
      if (x is Double || x is Single)
      {
            fx = (double) x;
            fy = (double) y;
            return Math.Round(fx * 1000).Equals(Math.Round(fy * 1000));
      }
      else
      {
         return x.Equals(y);
      }
   }
   
   public int GetHashCode(object obj)
   {
      if (obj is Single || obj is Double)
         return Math.Round(((double) obj) * 1000).GetHashCode();
      else
         return obj.GetHashCode();
   }                
}

public class Example
{
   public static void Main()
   {
      var rate1 = Tuple.Create("New York", .014505, -.1042733, 
                               .0354833, .093644, .0290792);
      var rate2 = Tuple.Create("Unknown City", .014505, -.1042733, 
                               .0354833, .093644, .0290792);
      var rate3 = Tuple.Create("Unknown City", .014505, -.1042733, 
                               .0354833, .093644, .029079);
      var rate4 = Tuple.Create("San Francisco", -.0332858, -.0512803, 
                               .0662544, .0728964, .0491912);
      IStructuralEquatable eq = rate1;
      // Compare first tuple with remaining two tuples.
      Console.WriteLine("{0} = ", rate1.ToString());
      Console.WriteLine("   {0} : {1}", rate2, 
                        eq.Equals(rate2, new RateComparer<string, double, double, double, double, double>()));
      Console.WriteLine("   {0} : {1}", rate3, 
                        eq.Equals(rate3, new RateComparer<string, double, double, double, double, double>()));
      Console.WriteLine("   {0} : {1}", rate4, 
                        eq.Equals(rate4, new RateComparer<string, double, double, double, double, double>()));
   }
}
// The example displays the following output:
//    (New York, 0.014505, -0.1042733, 0.0354833, 0.093644, 0.0290792) =
//       (Unknown City, 0.014505, -0.1042733, 0.0354833, 0.093644, 0.0290792) : True
//       (Unknown City, 0.014505, -0.1042733, 0.0354833, 0.093644, 0.029079) : True
//       (San Francisco, -0.0332858, -0.0512803, 0.0662544, 0.0728964, 0.0491912) : False
// </Snippet2>