using System;

public class Example
{
   public static void Main()
   {
      TestForEquality();
      Console.WriteLine();
      TestForApproximateEquality();
   }
      
   private static void TestForEquality()
   {
      // <Snippet4>
      System.Numerics.Complex c1 = new System.Numerics.Complex(3.33333, .142857);
      System.Numerics.Complex c2 = new System.Numerics.Complex(10/3.0, 1.0/7);
      Console.WriteLine("{0} = {1}: {2}", c1, c2, c1.Equals(c2));       
      // The example displays the following output:
      //    (3.33333, 0.142857) = (3.33333333333333, 0.142857142857143): False
      // </Snippet4>
   }

   private static void TestForApproximateEquality()
   {
      // <Snippet5>
      System.Numerics.Complex c1 = new System.Numerics.Complex(3.33333, .142857);
      System.Numerics.Complex c2 = new System.Numerics.Complex(10/3.0, 1.0/7);
      double difference = .0001;
      
      // Compare the values
      bool result = (Math.Abs(c1.Real - c2.Real) <= c1.Real * difference) &
                    (Math.Abs(c1.Imaginary - c2.Imaginary) <= c1.Imaginary * difference);
      Console.WriteLine("{0} = {1}: {2}", c1, c2, result);       
      // The example displays the following output:
      //    (3.33333, 0.142857) = (3.33333333333333, 0.142857142857143): True
      // </Snippet5>
   }
}
