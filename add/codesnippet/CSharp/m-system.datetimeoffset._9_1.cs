      DateTimeOffset quarterDate = new DateTimeOffset(2007, 1, 1, 0, 0, 0, 
                                       DateTimeOffset.Now.Offset);
      for (int ctr = 1; ctr <= 4; ctr++)
      {
         Console.WriteLine("Quarter {0}: {1:MMMM d}", ctr, quarterDate);
         quarterDate = quarterDate.AddMonths(3);
      }   
      // This example produces the following output:
      //       Quarter 1: January 1
      //       Quarter 2: April 1
      //       Quarter 3: July 1
      //       Quarter 4: October 1      