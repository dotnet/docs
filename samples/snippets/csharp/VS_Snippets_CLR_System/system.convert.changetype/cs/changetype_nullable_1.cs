// <Snippet8>
using System;

public class Example
{
   public static void Main()
   {
      int? intValue1 = 12893;
      double dValue1 = (double) Convert.ChangeType(intValue1, typeof(Double), null);
      Console.WriteLine("{0} ({1})--> {2} ({3})", intValue1, intValue1.GetType().Name,
                        dValue1, dValue1.GetType().Name);
      

      float fValue1 = 16.3478f;
      int? intValue2 = (int) fValue1; 
      Console.WriteLine("{0} ({1})--> {2} ({3})", fValue1, fValue1.GetType().Name,
                        intValue2, intValue2.GetType().Name);
   }
}
// The example displays the following output:
//    12893 (Int32)--> 12893 (Double)
//    16.3478 (Single)--> 16 (Int32)
// </Snippet8>
