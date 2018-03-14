using System;

public class Example
{
   public static void Main()
   {
      // <Snippet2>
      System.Numerics.Complex c1 = new System.Numerics.Complex(6.7, -1.3);
      System.Numerics.Complex c2 = new System.Numerics.Complex(1.4, 3.8);
      System.Numerics.Complex result = c1 - c2;
      Console.WriteLine("{0} - {1} = {2}", c1, c2, result);
      // The example displays the following output:
      //       (6.7, -1.3); - (1.4, 3.8); = (5.3, -5.1)      
      // </Snippet2>
   }
}
