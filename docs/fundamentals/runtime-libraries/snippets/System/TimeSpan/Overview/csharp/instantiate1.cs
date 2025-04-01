using System;

public class Example
{
   public static void Main()
   {
      Implicit();
      Console.WriteLine();
      Explicit();
      Console.WriteLine();
      TimeSpanOperation();
      Console.WriteLine();
      Parse();
      Console.WriteLine();
   }

   private static void Implicit()
   {
      // <Snippet2>
      TimeSpan interval = new TimeSpan();
      Console.WriteLine(interval.Equals(TimeSpan.Zero));    // Displays "True".
      // </Snippet2>
   }
   
   private static void Explicit()
   {
      // <Snippet3>
      TimeSpan interval = new TimeSpan(2, 14, 18);
      Console.WriteLine(interval.ToString());              
      
      // Displays "02:14:18".
      // </Snippet3>
   }   
   
   private static void TimeSpanOperation()
   {
      // <Snippet4>
      DateTime departure = new DateTime(2010, 6, 12, 18, 32, 0);
      DateTime arrival = new DateTime(2010, 6, 13, 22, 47, 0);
      TimeSpan travelTime = arrival - departure;  
      Console.WriteLine($"{arrival} - {departure} = {travelTime}");      
      
      // The example displays the following output:
      //       6/13/2010 10:47:00 PM - 6/12/2010 6:32:00 PM = 1.04:15:00
      // </Snippet4>
   }
   
   private static void Parse()
   {
      // <Snippet5>
      string[] values = { "12", "31.", "5.8:32:16", "12:12:15.95", ".12"};
      foreach (string value in values)
      {
         try {
            TimeSpan ts = TimeSpan.Parse(value);
            Console.WriteLine($"'{value}' --> {ts}");
         }
         catch (FormatException) {
            Console.WriteLine($"Unable to parse '{value}'");
         }
         catch (OverflowException) {
            Console.WriteLine($"'{value}' is outside the range of a TimeSpan.");
         }   
      }
      
      // The example displays the following output:
      //       '12' --> 12.00:00:00
      //       Unable to parse '31.'
      //       '5.8:32:16' --> 5.08:32:16
      //       '12:12:15.95' --> 12:12:15.9500000
      //       Unable to parse '.12'  
      // </Snippet5>    
   }
}
