using System;

public class Example
{
   public static void Main()
   {
      ConvertInt32();
      Console.WriteLine("-----");
      ConvertInt64();
   }

   private static void ConvertInt32()
   {
      // Create a NumberFormatInfo object and set several of its
      // properties that control default integer formatting.
      System.Globalization.NumberFormatInfo provider = new System.Globalization.NumberFormatInfo();
      provider.NegativeSign = "minus ";

      int[] values = { -20, 0, 100 };
      
      foreach (int value in values)
         Console.WriteLine("{0,-5}  -->  {1,8}", 
                           value, Convert.ToString(value, provider));
      // The example displays the following output:
      //       -20    -->  minus 20
      //       0      -->         0
      //       100    -->       100
   }
   
   private static void ConvertInt64()
   {
      // <Snippet28>
      // Create a NumberFormatInfo object and set several of its
      // properties that control default integer formatting.
      System.Globalization.NumberFormatInfo provider = new System.Globalization.NumberFormatInfo();
      provider.NegativeSign = "minus ";

      long[] values = { -200, 0, 1000 };
      
      foreach (long value in values)
         Console.WriteLine("{0,-6}  -->  {1,10}", 
                           value, Convert.ToString(value, provider));
      // The example displays the following output:
      //       -200    -->   minus 200
      //       0       -->           0
      //       1000    -->        1000
      // </Snippet28>
   }

}
