using System;

public class Class1
{
   public static void Main()
   {
      CeilingWithDecimal();
      Console.WriteLine();
      CeilingWithDouble();
   }

   private static void CeilingWithDecimal()
   {
      // <Snippet1>
      decimal[] values = {7.03m, 7.64m, 0.12m, -0.12m, -7.1m, -7.6m};
      Console.WriteLine("  Value          Ceiling          Floor\n");
      foreach (decimal value in values)
         Console.WriteLine("{0,7} {1,16} {2,14}", 
                           value, Math.Ceiling(value), Math.Floor(value));
      // The example displays the following output to the console:
      //         Value          Ceiling          Floor
      //       
      //          7.03                8              7
      //          7.64                8              7
      //          0.12                1              0
      //         -0.12                0             -1
      //          -7.1               -7             -8
      //          -7.6               -7             -8
      // </Snippet1>   
   }

   private static void CeilingWithDouble()
   {
      // <Snippet2>
      double[] values = {7.03, 7.64, 0.12, -0.12, -7.1, -7.6};
      Console.WriteLine("  Value          Ceiling          Floor\n");
      foreach (double value in values)
         Console.WriteLine("{0,7} {1,16} {2,14}", 
                           value, Math.Ceiling(value), Math.Floor(value));
      // The example displays the following output to the console:
      //         Value          Ceiling          Floor
      //       
      //          7.03                8              7
      //          7.64                8              7
      //          0.12                1              0
      //         -0.12                0             -1
      //          -7.1               -7             -8
      //          -7.6               -7             -8
      // </Snippet2>   
   }
}
