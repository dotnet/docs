      Dim currentDate As New DateTimeOffset(#5/10/2008 5:32:16AM#, _
                                            DateTimeOffset.Now.Offset) 
      Dim currentTime As TimeSpan = currentDate.TimeOfDay
      Console.WriteLine("The current time is {0}.", currentTime.ToString())
      ' The example produces the following output: 
      '       The current time is 05:32:16.