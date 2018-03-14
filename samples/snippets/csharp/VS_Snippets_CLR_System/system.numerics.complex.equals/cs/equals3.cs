using System;

public class Example
{
   public static void Main()
   {
      // <Snippet6>
      double n1 = 16.33;
      System.Numerics.Complex c1 = 
             new System.Numerics.Complex(16.33, 0);
      Console.WriteLine(c1.Equals(n1));               // Returns true.
      // </Snippet6>
   }
}
