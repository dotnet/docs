using System;

public class Example
{
   public static void Main()
   {
      int dimension1 = 10;
      int dimension2 = -1;
      try {
         Array arr = Array.CreateInstance(typeof(String), 
                                          dimension1, dimension2);
      }
      catch (ArgumentOutOfRangeException e) {
         if (e.ActualValue != null)
            Console.WriteLine("{0} is an invalid value for {1}: ", e.ActualValue, e.ParamName);
         Console.WriteLine(e.Message);
      }
   }
}
// The example displays the following output:
//     Non-negative number required.
//     Parameter name: length2