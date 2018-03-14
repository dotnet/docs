// <Snippet3>
using System;

public class Example
{
   public static void Main()
   {
      string value;
      double number;
      
      value = Double.MinValue.ToString();
      if (Double.TryParse(value, out number))
         Console.WriteLine(number);
      else
         Console.WriteLine("{0} is outside the range of a Double.", 
                           value);
      
      value = Double.MaxValue.ToString();
      if (Double.TryParse(value, out number))
         Console.WriteLine(number);
      else
         Console.WriteLine("{0} is outside the range of a Double.",
                           value);
   }
}
// The example displays the following output:
//    -1.79769313486232E+308 is outside the range of the Double type.
//    1.79769313486232E+308 is outside the range of the Double type.            
// </Snippet3>
