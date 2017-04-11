// <Snippet7>
using System;

[assembly: CLSCompliant(true)]
public class Example
{
   public static void Main()
   {
      DateTime birthdate = new DateTime(1993, 7, 28);
      DateTime[] dates = { new DateTime(1993, 8, 16), 
                           new DateTime(1994, 7, 28), 
                           new DateTime(2000, 10, 16), 
                           new DateTime(2003, 7, 27), 
                           new DateTime(2007, 5, 27) };

      foreach (DateTime dateValue in dates)
      {
         TimeSpan interval = dateValue - birthdate;
         // Get the approximate number of years, without accounting for leap years.
         int years = ((int) interval.TotalDays) / 365;
         // See if adding the number of years exceeds dateValue.
         string output;
         if (birthdate.AddYears(years) <= dateValue) {
            output = String.Format("You are now {0} years old.", years);
            Console.WriteLine(output);
         }   
         else {
            output = String.Format("You are now {0} years old.", years - 1);
            Console.WriteLine(output);
         }      
      }
   }
}
// The example displays the following output:
//       You are now 0 years old.
//       You are now 1 years old.
//       You are now 7 years old.
//       You are now 9 years old.
//       You are now 13 years old.
// </Snippet7>
