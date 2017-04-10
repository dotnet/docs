using System;

public class Example
{
   public static void Main()
   {
      // <Snippet1>
      string dateFormat = "MM/dd/yyyy hh:mm:ss.fffffff"; 
      DateTime date1 = new DateTime(2010, 9, 8, 16, 0, 0);
      Console.WriteLine("Original date: {0} ({1:N0} ticks)\n",
                        date1.ToString(dateFormat), date1.Ticks);
      
      DateTime date2 = date1.AddMilliseconds(1);
      Console.WriteLine("Second date:   {0} ({1:N0} ticks)",
                        date2.ToString(dateFormat), date2.Ticks);
      Console.WriteLine("Difference between dates: {0} ({1:N0} ticks)\n",
                        date2 - date1, date2.Ticks - date1.Ticks);                        
      
      DateTime date3 = date1.AddMilliseconds(1.5);
      Console.WriteLine("Third date:    {0} ({1:N0} ticks)",
                        date3.ToString(dateFormat), date3.Ticks);
      Console.WriteLine("Difference between dates: {0} ({1:N0} ticks)",
                        date3 - date1, date3.Ticks - date1.Ticks);                        
      // The example displays the following output:
      //    Original date: 09/08/2010 04:00:00.0000000 (634,195,584,000,000,000 ticks)
      //    
      //    Second date:   09/08/2010 04:00:00.0010000 (634,195,584,000,010,000 ticks)
      //    Difference between dates: 00:00:00.0010000 (10,000 ticks)
      //    
      //    Third date:    09/08/2010 04:00:00.0020000 (634,195,584,000,020,000 ticks)
      //    Difference between dates: 00:00:00.0020000 (20,000 ticks)      
      // </Snippet1>
   }
}
