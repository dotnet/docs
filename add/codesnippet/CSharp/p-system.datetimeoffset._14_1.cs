      DateTimeOffset currentDate = new DateTimeOffset(2008, 5, 10, 5, 32, 16, 
                                            DateTimeOffset.Now.Offset); 
      TimeSpan currentTime = currentDate.TimeOfDay;
      Console.WriteLine("The current time is {0}.", currentTime.ToString());
      // The example produces the following output: 
      //       The current time is 05:32:16.