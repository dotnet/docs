      DateTimeOffset date1 = new DateTimeOffset(2008, 3, 5, 5, 45, 35, 649, 
                                      new TimeSpan(-7, 0, 0));
      Console.WriteLine("Milliseconds value of {0} is {1}.", 
                        date1.ToString("MM/dd/yyyy hh:mm:ss.fff"), 
                        date1.Millisecond);
      // The example produces the following output:
      //
      // Milliseconds value of 03/05/2008 05:45:35.649 is 649.