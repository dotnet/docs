      DateTimeOffset theTime = new DateTimeOffset(2008, 9, 7, 11, 25, 0, 
                                             DateTimeOffset.Now.Offset);
      Console.WriteLine("The month component of {0} is {1}.", 
                        theTime, theTime.Month);

      Console.WriteLine("The month component of {0} is{1}.", 
                        theTime, theTime.ToString(" M"));

      Console.WriteLine("The month component of {0} is {1}.", 
                        theTime, theTime.ToString("MM"));
      // The example produces the following output:
      //    The month component of 9/7/2008 11:25:00 AM -08:00 is 9.
      //    The month component of 9/7/2008 11:25:00 AM -08:00 is 9.
      //    The month component of 9/7/2008 11:25:00 AM -08:00 is 09.      