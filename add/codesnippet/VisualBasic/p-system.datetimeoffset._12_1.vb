      ' Attempt to initialize date to number of ticks
      ' in July 1, 2008 1:23:07.      
      '
      ' There are 10,000,000 100-nanosecond intervals in a second
      Const NSPerSecond As Long = 10000000
      Dim ticks As Long
      ticks = 7 * NSPerSecond                         ' Ticks in a 7 seconds 
      ticks += 23 * 60 * NSPerSecond                  ' Ticks in 23 minutes
      ticks += 1 * 60 * 60 * NSPerSecond              ' Ticks in 1 hour
      ticks += 60 * 60 * 24 * NSPerSecond             ' Ticks in 1 day
      ticks += 181 * 60 * 60 * 24 * NSPerSecond       ' Ticks in 6 months 
      ticks += 2007 * 60 * 60 * 24 * 365l * NSPerSecond   ' Ticks in 2007 years 
      ticks += 486 * 60 * 60 * 24 * NSPerSecond       ' Adjustment for leap years      
      Dim dto As DateTimeOffset = New DateTimeOffset( _
                                  ticks, _
                                  DateTimeOffset.Now.Offset)
      Console.WriteLine("There are {0:n0} ticks in {1}.", _
                        dto.Ticks, _
                        dto.ToString())
      ' The example displays the following output:
      '       There are 633,504,721,870,000,000 ticks in 7/1/2008 1:23:07 AM -08:00.      