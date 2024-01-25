﻿// <Snippet5>
using System;

public class Example
{
   public static void Main()
   {
      float[] values = { 0f, Single.Epsilon, Single.Epsilon * .5f };
      
      for (int ctr = 0; ctr <= values.Length - 2; ctr++)
      {
         for (int ctr2 = ctr + 1; ctr2 <= values.Length - 1; ctr2++)
         {
            Console.WriteLine("{0:r} = {1:r}: {2}", 
                              values[ctr], values[ctr2],  
                              values[ctr].Equals(values[ctr2]));
         }
         Console.WriteLine();
      }      
   }
}
// The example displays the following output:
//       0 = 1.401298E-45: False
//       0 = 0: True
//       
//       1.401298E-45 = 0: False
// </Snippet5>
