using System;

public class Example
{
   public static void Main()
   {
   // <Snippet3>
      string value;
      
      value = Double.MinValue.ToString();
      try {
         Console.WriteLine(Double.Parse(value));
      }   
      catch (OverflowException) {
         Console.WriteLine("{0} is outside the range of the Double type.",
                           value);
      }
      
      value = Double.MaxValue.ToString();
      try {
         Console.WriteLine(Double.Parse(value));
      }
      catch (OverflowException) {
         Console.WriteLine("{0} is outside the range of the Double type.",
                           value);
      }
   // The example displays the following output:
   //    -1.79769313486232E+308 is outside the range of the Double type.
   //    1.79769313486232E+308 is outside the range of the Double type.
   // </Snippet3>   
   }
}
