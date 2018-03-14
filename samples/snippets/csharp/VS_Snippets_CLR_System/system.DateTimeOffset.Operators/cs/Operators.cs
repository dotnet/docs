using System;

public class Class1
{
   public static void Main()
   {
      ShowAddition();  
      ShowEquality();  
      ShowGreaterThan();
      ShowGreaterThanOrEqualTo();
      ShowImplicitConversions(); 
      ShowInequality(); 
      ShowLessThan(); 
      ShowLessThanOrEqualTo();  
      ShowSubtraction1(); 
      ShowSubtraction2();
   }

   private static void ShowAddition()
   {
      // <Snippet1>
      DateTimeOffset date1 = new DateTimeOffset(2008, 1, 1, 13, 32, 45, 
                             new TimeSpan(-5, 0, 0)); 
      TimeSpan interval1 = new TimeSpan(202, 3, 30, 0);
      TimeSpan interval2 = new TimeSpan(5, 0, 0, 0);      
      DateTimeOffset date2; 
      
      Console.WriteLine(date1);         // Displays 1/1/2008 1:32:45 PM -05:00
      date2 = date1 + interval1;
      Console.WriteLine(date2);         // Displays 7/21/2008 5:02:45 PM -05:00
      date2 += interval2;
      Console.WriteLine(date2);         // Displays 7/26/2008 5:02:45 PM -05:00     
      // </Snippet1>
   }

   private static void ShowEquality()
   {
      // <Snippet2>
      DateTimeOffset date1 = new DateTimeOffset(2007, 6, 3, 14, 45, 0, 
                   new TimeSpan(-7, 0, 0));
      DateTimeOffset date2 = new DateTimeOffset(2007, 6, 3, 15, 45, 0,
                   new TimeSpan(-6, 0, 0));
      DateTimeOffset date3 = new DateTimeOffset(date1.DateTime, 
                   new TimeSpan(-6, 0, 0));
      Console.WriteLine(date1 == date2);        // Displays True
      Console.WriteLine(date1 == date3);        // Displays False 
      // </Snippet2>
   }

   private static void ShowGreaterThan()
   {
      // <Snippet3>
      DateTimeOffset date1 = new DateTimeOffset(2007, 6, 3, 14, 45, 0, 
                   new TimeSpan(-7, 0, 0));
      DateTimeOffset date2 = new DateTimeOffset(2007, 6, 3, 15, 45, 0,
                   new TimeSpan(-6, 0, 0));
      DateTimeOffset date3 = new DateTimeOffset(date1.DateTime, 
                   new TimeSpan(-6, 0, 0));
      Console.WriteLine(date1 > date2);        // Displays False
      Console.WriteLine(date1 > date3);        // Displays True 
      // </Snippet3>
   }

   private static void ShowGreaterThanOrEqualTo()
   {
      // <Snippet5>
      DateTimeOffset date1 = new DateTimeOffset(2007, 6, 3, 14, 45, 0, 
                   new TimeSpan(-7, 0, 0));
      DateTimeOffset date2 = new DateTimeOffset(2007, 6, 3, 15, 45, 0,
                   new TimeSpan(-7, 0, 0));
      DateTimeOffset date3 = new DateTimeOffset(date1.DateTime, 
                   new TimeSpan(-6, 0, 0));
      DateTimeOffset date4 = date1;
      Console.WriteLine(date1 >= date2);        // Displays False
      Console.WriteLine(date1 >= date3);        // Displays True 
      Console.WriteLine(date1 >= date4);        // Displays True 
      // </Snippet5>
   }

   private static void ShowImplicitConversions()
   {
      // <Snippet7>
      DateTimeOffset timeWithOffset; 
      timeWithOffset = new DateTime(1008, 7, 3, 18, 45, 0);
      Console.WriteLine(timeWithOffset.ToString());
      
      timeWithOffset = DateTime.UtcNow;
      Console.WriteLine(timeWithOffset.ToString());
      
      timeWithOffset = DateTime.SpecifyKind(DateTime.Now, 
                                            DateTimeKind.Unspecified);
      Console.WriteLine(timeWithOffset.ToString());
   
      timeWithOffset = new DateTime(2008, 1, 1, 2, 30, 0) + 
                       new TimeSpan(1, 0, 0, 0);
      Console.WriteLine(timeWithOffset.ToString());
      // The example produces the following output if run on 3/20/2007 
      // at 6:25 PM on a computer in the U.S. Pacific Daylight Time zone:
      //       7/3/2008 6:45:00 PM -07:00
      //       3/21/2007 1:25:52 AM +00:00
      //       3/20/2007 6:25:52 PM -07:00
      //       1/2/2008 2:30:00 AM -08:00      
      // </Snippet7>
   }

   private static void ShowInequality()
   {
      // <Snippet8>
      DateTimeOffset date1 = new DateTimeOffset(2007, 6, 3, 14, 45, 0, 
                   new TimeSpan(-7, 0, 0));
      DateTimeOffset date2 = new DateTimeOffset(2007, 6, 3, 15, 45, 0,
                   new TimeSpan(-6, 0, 0));
      DateTimeOffset date3 = new DateTimeOffset(date1.DateTime, 
                   new TimeSpan(-6, 0, 0));
      Console.WriteLine(date1 != date2);        // Displays False
      Console.WriteLine(date1 != date3);        // Displays True 
      // </Snippet8>
   }

   private static void ShowLessThan()
   {
      // <Snippet10>
      DateTimeOffset date1 = new DateTimeOffset(2007, 6, 3, 14, 45, 0, 
                   new TimeSpan(-7, 0, 0));
      DateTimeOffset date2 = new DateTimeOffset(2007, 6, 3, 15, 45, 0,
                   new TimeSpan(-6, 0, 0));
      DateTimeOffset date3 = new DateTimeOffset(date1.DateTime, 
                   new TimeSpan(-8, 0, 0));
      Console.WriteLine(date1 < date2);        // Displays False
      Console.WriteLine(date1 < date3);        // Displays True 
      // </Snippet10>
   }

   private static void ShowLessThanOrEqualTo()
   {
      // <Snippet12>
      DateTimeOffset date1 = new DateTimeOffset(2007, 6, 3, 14, 45, 0, 
                   new TimeSpan(-7, 0, 0));
      DateTimeOffset date2 = new DateTimeOffset(2007, 6, 3, 15, 45, 0,
                   new TimeSpan(-7, 0, 0));
      DateTimeOffset date3 = new DateTimeOffset(date1.DateTime, 
                   new TimeSpan(-6, 0, 0));
      DateTimeOffset date4 = date1;
      Console.WriteLine(date1 <= date2);        // Displays True
      Console.WriteLine(date1 <= date3);        // Displays False 
      Console.WriteLine(date1 <= date4);        // Displays True 
      // </Snippet12>
   }

   private static void ShowSubtraction1()
   {
      // <Snippet14>
      DateTimeOffset firstDate = new DateTimeOffset(2008, 3, 25, 18, 0, 0, 
                                                    new TimeSpan(-7, 0, 0));
      DateTimeOffset secondDate = new DateTimeOffset(2008, 3, 25, 18, 0, 0, 
                                                     new TimeSpan(-5, 0, 0));
      DateTimeOffset thirdDate = new DateTimeOffset(2008, 2, 28, 9, 0, 0, 
                                                    new TimeSpan(-7, 0, 0));
      TimeSpan difference;
      
      difference = firstDate - secondDate;
      Console.WriteLine("({0}) - ({1}): {2} days, {3}:{4:d2}", 
                        firstDate.ToString(), 
                        secondDate.ToString(), 
                        difference.Days, 
                        difference.Hours, 
                        difference.Minutes);      
      
      difference = firstDate - thirdDate;
      Console.WriteLine("({0}) - ({1}): {2} days, {3}:{4:d2}", 
                        firstDate.ToString(), 
                        secondDate.ToString(), 
                        difference.Days, 
                        difference.Hours, 
                        difference.Minutes); 
      // The example produces the following output:
      //    (3/25/2008 6:00:00 PM -07:00) - (3/25/2008 6:00:00 PM -05:00): 0 days, 2:00
      //    (3/25/2008 6:00:00 PM -07:00) - (3/25/2008 6:00:00 PM -05:00): 26 days, 9:00                                 
      // </Snippet14>   
   }

   private static void ShowSubtraction2()
   {
      // <Snippet15>   
      DateTimeOffset offsetDate = new DateTimeOffset(2007, 12, 3, 11, 30, 0, 
                                     new TimeSpan(-8, 0, 0)); 
      TimeSpan duration = new TimeSpan(7, 18, 0, 0);
      Console.WriteLine(offsetDate - duration);  // Displays 11/25/2007 5:30:00 PM -08:00
      // </Snippet15>   
   }
}
