   private static void CompareForEquality1()
   {
      DateTimeOffset firstTime = new DateTimeOffset(2007, 9, 1, 6, 45, 0, 
                                 new TimeSpan(-7, 0, 0));

      DateTimeOffset secondTime = firstTime;
      Console.WriteLine("{0} = {1}: {2}", 
                        firstTime, secondTime, 
                        firstTime.Equals(secondTime));

      secondTime = new DateTimeOffset(2007, 9, 1, 6, 45, 0, 
                       new TimeSpan(-6, 0, 0));      
      Console.WriteLine("{0} = {1}: {2}", 
                       firstTime, secondTime, 
                       firstTime.Equals(secondTime));
   
      secondTime = new DateTimeOffset(2007, 9, 1, 8, 45, 0, 
                       new TimeSpan(-5, 0, 0));
      Console.WriteLine("{0} = {1}: {2}", 
                       firstTime, secondTime, 
                       firstTime.Equals(secondTime));
      // The example displays the following output to the console:
      //      9/1/2007 6:45:00 AM -07:00 = 9/1/2007 6:45:00 AM -07:00: True
      //      9/1/2007 6:45:00 AM -07:00 = 9/1/2007 6:45:00 AM -06:00: False
      //      9/1/2007 6:45:00 AM -07:00 = 9/1/2007 8:45:00 AM -05:00: True       