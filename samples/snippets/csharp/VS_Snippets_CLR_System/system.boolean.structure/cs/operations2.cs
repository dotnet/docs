// <Snippet13>
using System;

public class Example
{
   public static void Main()
   {
      bool[] hasServiceCharges = { true, false };
      Decimal subtotal = 120.62m;
      Decimal shippingCharge = 2.50m;
      Decimal serviceCharge = 5.00m;
      
      foreach (var hasServiceCharge in hasServiceCharges) {
         Decimal total = subtotal + shippingCharge + 
                                (hasServiceCharge ? serviceCharge : 0);
         Console.WriteLine("hasServiceCharge = {1}: The total is {0:C2}.", 
                           total, hasServiceCharge);                       
      }
   }
}
// The example displays output like the following:
//       hasServiceCharge = True: The total is $128.12.
//       hasServiceCharge = False: The total is $123.12.
// </Snippet13>
