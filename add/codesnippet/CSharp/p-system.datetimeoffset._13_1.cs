      DateTimeOffset theTime = new DateTimeOffset(2008, 3, 1, 14, 15, 00, 
                                             DateTimeOffset.Now.Offset);
      Console.WriteLine("The hour component of {0} is {1}.", 
                        theTime, theTime.Hour);

      Console.WriteLine("The hour component of {0} is{1}.", 
                        theTime, theTime.ToString(" H"));

      Console.WriteLine("The hour component of {0} is {1}.", 
                        theTime, theTime.ToString("HH"));
      // The example produces the following output:
      //    The hour component of 3/1/2008 2:15:00 PM -08:00 is 14.
      //    The hour component of 3/1/2008 2:15:00 PM -08:00 is 14.
      //    The hour component of 3/1/2008 2:15:00 PM -08:00 is 14.