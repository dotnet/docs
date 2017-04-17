// <snippet4>
using System;

class Sample 
{
    public static void Main() 
    {
       double posValue =  3.45;
       double negValue = -3.45;

       // Round a positive and a negative value using the default. 
       double result = Math.Round(posValue, 1);
       Console.WriteLine("{0,4} = Math.Round({1,5}, 1)", result, posValue);
       result = Math.Round(negValue, 1);
       Console.WriteLine("{0,4} = Math.Round({1,5}, 1)\n", result, negValue);

       // Round a positive value using a MidpointRounding value. 
       result = Math.Round(posValue, 1, MidpointRounding.ToEven);
       Console.WriteLine("{0,4} = Math.Round({1,5}, 1, MidpointRounding.ToEven)", 
                         result, posValue);
       result = Math.Round(posValue, 1, MidpointRounding.AwayFromZero);
       Console.WriteLine("{0,4} = Math.Round({1,5}, 1, MidpointRounding.AwayFromZero)\n", 
                         result, posValue);

       // Round a negative value using a MidpointRounding value. 
       result = Math.Round(negValue, 1, MidpointRounding.ToEven);
       Console.WriteLine("{0,4} = Math.Round({1,5}, 1, MidpointRounding.ToEven)", 
                         result, negValue);
       result = Math.Round(negValue, 1, MidpointRounding.AwayFromZero);
       Console.WriteLine("{0,4} = Math.Round({1,5}, 1, MidpointRounding.AwayFromZero)\n", 
                         result, negValue);
   }
}
// The example displays the following output:
//        3.4 = Math.Round( 3.45, 1)
//       -3.4 = Math.Round(-3.45, 1)
//       
//        3.4 = Math.Round( 3.45, 1, MidpointRounding.ToEven)
//        3.5 = Math.Round( 3.45, 1, MidpointRounding.AwayFromZero)
//       
//       -3.4 = Math.Round(-3.45, 1, MidpointRounding.ToEven)
//       -3.5 = Math.Round(-3.45, 1, MidpointRounding.AwayFromZero)
// </Snippet4>
