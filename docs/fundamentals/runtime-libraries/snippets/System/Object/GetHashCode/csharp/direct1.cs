// <Snippet1>
using System;

public struct Number
{
   private int n;

   public Number(int value)
   {
      n = value;
   }

   public int Value
   {
      get { return n; }
   }

   public override bool Equals(Object obj)
   {
      if (obj == null || ! (obj is Number))
         return false;
      else
         return n == ((Number) obj).n;
   }

   public override int GetHashCode()
   {
      return n;
   }

   public override string ToString()
   {
      return n.ToString();
   }
}

public class Example1
{
   public static void Main()
   {
      Random rnd = new Random();
      for (int ctr = 0; ctr <= 9; ctr++) {
         int randomN = rnd.Next(Int32.MinValue, Int32.MaxValue);
         Number n = new Number(randomN);
         Console.WriteLine("n = {0,12}, hash code = {1,12}", n, n.GetHashCode());
      }
   }
}
// The example displays output like the following:
//       n =   -634398368, hash code =   -634398368
//       n =   2136747730, hash code =   2136747730
//       n =  -1973417279, hash code =  -1973417279
//       n =   1101478715, hash code =   1101478715
//       n =   2078057429, hash code =   2078057429
//       n =   -334489950, hash code =   -334489950
//       n =    -68958230, hash code =    -68958230
//       n =   -379951485, hash code =   -379951485
//       n =    -31553685, hash code =    -31553685
//       n =   2105429592, hash code =   2105429592
// </Snippet1>
