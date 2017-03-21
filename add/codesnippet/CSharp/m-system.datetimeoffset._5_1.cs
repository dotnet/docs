      DateTimeOffset workDay = new DateTimeOffset(2008, 3, 1, 9, 0, 0, 
                         DateTimeOffset.Now.Offset);
      int month = workDay.Month;
      // Start with the first Monday of the month
      if (workDay.DayOfWeek != DayOfWeek.Monday)
      {
         if (workDay.DayOfWeek == DayOfWeek.Sunday)
            workDay = workDay.AddDays(1);
         else   
            workDay = workDay.AddDays(8 - (int)workDay.DayOfWeek);
      }
      Console.WriteLine("Beginning of Work Week In {0:MMMM} {0:yyyy}:", workDay);
      // Add one week to the current date 
      do    
      {
         Console.WriteLine("   {0:dddd}, {0:MMMM}{0: d}", workDay);
         workDay = workDay.AddDays(7);
      } while (workDay.Month == month); 
      // The example produces the following output:
      //    Beginning of Work Week In March 2008:
      //       Monday, March 3
      //       Monday, March 10
      //       Monday, March 17
      //       Monday, March 24
      //       Monday, March 31             