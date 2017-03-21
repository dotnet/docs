      Dim takeOff As New DateTimeOffset(#6/1/2007 7:55AM#, _
                                        New TimeSpan(-5, 0, 0))
      Dim currentTime As DateTimeOffset = takeOff
      Dim flightTimes() As TimeSpan = New TimeSpan() _
                        {New TimeSpan(2, 25, 0), New TimeSpan(1, 48, 0)}
      Console.WriteLine("Takeoff is scheduled for {0:d} at {0:T}.", _
                        takeOff)
      For ctr As Integer = flightTimes.GetLowerBound(0) To _
                           flightTimes.GetUpperBound(0)
         currentTime = currentTime.Add(flightTimes(ctr))
         Console.WriteLine("Destination #{0} at {1}.", ctr + 1, currentTime)
      Next