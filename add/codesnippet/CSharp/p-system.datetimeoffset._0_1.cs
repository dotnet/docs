      DateTimeOffset theTime = new DateTimeOffset(2007, 5, 1, 16, 35, 0, 
                                                  DateTimeOffset.Now.Offset);
      Console.WriteLine("The day component of {0} is {1}.", 
                        theTime, theTime.Day);

      Console.WriteLine("The day component of {0} is{1}.", 
                        theTime, theTime.ToString(" d"));

      Console.WriteLine("The day component of {0} is {1}.", 
                        theTime, theTime.ToString("dd"));
      // The example produces the following output:
      //    The day component of 5/1/2007 4:35:00 PM -08:00 is 1.
      //    The day component of 5/1/2007 4:35:00 PM -08:00 is 1.
      //    The day component of 5/1/2007 4:35:00 PM -08:00 is 01.