      DateTimeOffset takeOff = new DateTimeOffset(2007, 6, 1, 7, 55, 0, 
                                   new TimeSpan(-5, 0, 0));
      DateTimeOffset currentTime = takeOff;
      TimeSpan[] flightTimes = new TimeSpan[]
                        {new TimeSpan(2, 25, 0), new TimeSpan(1, 48, 0)};
      Console.WriteLine("Takeoff is scheduled for {0:d} at {0:T}.", 
                        takeOff);
      for (int ctr = flightTimes.GetLowerBound(0); 
           ctr <= flightTimes.GetUpperBound(0); ctr++)
      {
         currentTime = currentTime.Add(flightTimes[ctr]);
         Console.WriteLine("Destination #{0} at {1}.", ctr + 1, currentTime);
      }