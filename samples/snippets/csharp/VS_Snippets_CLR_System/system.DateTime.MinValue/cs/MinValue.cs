using System;

public class Example
{
   public static void Main()
   {
      // <Snippet1>
      // Define an uninitialized date.
      DateTime date1 = new DateTime();
      Console.Write(date1);
      if (date1.Equals(DateTime.MinValue))
         Console.WriteLine("  (Equals Date.MinValue)");
      // The example displays the following output:
      //    1/1/0001 12:00:00 AM  (Equals Date.MinValue)
      // </Snippet1>         

      // <Snippet2>
      // Attempt to assign an out-of-range value to a DateTime constructor.
      long numberOfTicks = Int64.MaxValue;
      DateTime validDate;
      
      // Validate the value.
      if (numberOfTicks >= DateTime.MinValue.Ticks &&
          numberOfTicks <= DateTime.MaxValue.Ticks) 
         validDate = new DateTime(numberOfTicks);
      else if (numberOfTicks < DateTime.MinValue.Ticks) 
         Console.WriteLine("{0:N0} is less than {1:N0} ticks.", 
                           numberOfTicks, 
                           DateTime.MinValue.Ticks);      
      else
         Console.WriteLine("{0:N0} is greater than {1:N0} ticks.", 
                           numberOfTicks,
                           DateTime.MaxValue.Ticks);
      // The example displays the following output:
      //   9,223,372,036,854,775,807 is greater than 3,155,378,975,999,999,999 ticks.
      // </Snippet2>
   }
}
