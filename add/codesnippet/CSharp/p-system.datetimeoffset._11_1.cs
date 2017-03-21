      DateTimeOffset theTime = new DateTimeOffset(2008, 5, 1, 10, 3, 0, 
                                                 DateTimeOffset.Now.Offset);
      Console.WriteLine("The minute component of {0} is {1}.", 
                        theTime, theTime.Minute);

      Console.WriteLine("The minute component of {0} is{1}.", 
                        theTime, theTime.ToString(" m"));

      Console.WriteLine("The minute component of {0} is {1}.", 
                        theTime, theTime.ToString("mm"));
      // The example produces the following output:
      //    The minute component of 5/1/2008 10:03:00 AM -08:00 is 3.
      //    The minute component of 5/1/2008 10:03:00 AM -08:00 is 3.
      //    The minute component of 5/1/2008 10:03:00 AM -08:00 is 03.