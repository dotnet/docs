// <Snippet1>
using System;

public class Example
{
   public static void Main()
   {
      // Get the current date.
      DateTime thisDay = DateTime.Today;
      // Display the date in the default (general) format.
      Console.WriteLine(thisDay.ToString());
      Console.WriteLine();
      // Display the date in a variety of formats.
      Console.WriteLine(thisDay.ToString("d"));
      Console.WriteLine(thisDay.ToString("D"));
      Console.WriteLine(thisDay.ToString("g"));
   }
}
// The example displays output similar to the following:
//    5/3/2012 12:00:00 AM
//    
//    5/3/2012
//    Thursday, May 03, 2012
//    5/3/2012 12:00 AM
// </Snippet1>      
