// <Snippet2>
using System;

public class Example
{
   private static Random rnd;
   
   public static void Main()
   {
      rnd = new Random();
      Example ex = new Example();
      double value = MathLib.GetComputedValue(ex.GetInt(), ex.GetDouble());
      Console.WriteLine(value);
   }

   private int GetInt()
   {
      return rnd.Next(11, 100);
   }

   private double GetDouble()
   {
      return rnd.NextDouble();
   }
}
// </Snippet2>


public class MathLib
{
   public static double GetComputedValue(int val1, double val2)
   {
      return val1 * val2;
   }
}
