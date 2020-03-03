using System;

public class Example
{
   public static void Main()
   {
      // <Snippet5>
      Random rnd = new Random();
      
      Console.WriteLine("Generating 10 random numbers:");
                        
      for (uint ctr = 1; ctr <= 10; ctr++)
         Console.WriteLine($"{rnd.Next(),15:N0}");

      // The example displays output like the following:
      //
      //     Generating 10 random numbers:                  
      //         1,733,189,596
      //           566,518,090
      //         1,166,108,546
      //         1,931,426,514
      //         1,532,939,448
      //           762,207,767
      //           815,074,920
      //         1,521,208,785
      //         1,950,436,671
      //         1,266,596,666
      // </Snippet5>
   }
}
