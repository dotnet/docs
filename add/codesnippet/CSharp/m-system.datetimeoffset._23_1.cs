      const int SHIFT_LENGTH = 8;
      
      DateTimeOffset startTime = new DateTimeOffset(2007, 8, 6, 0, 0, 0, 
                           DateTimeOffset.Now.Offset);
      DateTimeOffset startOfShift = startTime.AddHours(SHIFT_LENGTH);
      
      Console.WriteLine("Shifts for the week of {0:D}", startOfShift);
      do
      { 
         // Exclude third shift
         if (startOfShift.Hour > 6)
            Console.WriteLine("   {0:d} at {0:T}", startOfShift);

         startOfShift = startOfShift.AddHours(SHIFT_LENGTH);
      } while (startOfShift.DayOfWeek != DayOfWeek.Saturday &
                 startOfShift.DayOfWeek != DayOfWeek.Sunday);
      // The example produces the following output:
      //
      //    Shifts for the week of Monday, August 06, 2007
      //       8/6/2007 at 8:00:00 AM
      //       8/6/2007 at 4:00:00 PM
      //       8/7/2007 at 8:00:00 AM
      //       8/7/2007 at 4:00:00 PM
      //       8/8/2007 at 8:00:00 AM
      //       8/8/2007 at 4:00:00 PM
      //       8/9/2007 at 8:00:00 AM
      //       8/9/2007 at 4:00:00 PM
      //       8/10/2007 at 8:00:00 AM
      //       8/10/2007 at 4:00:00 PM                 