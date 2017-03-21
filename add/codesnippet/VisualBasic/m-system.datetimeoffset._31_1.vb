      ' Local time changes on 3/11/2007 at 2:00 AM
      Dim originalTime, localTime As DateTimeOffset
      
      originalTime = New DateTimeOffset(#03/11/2007 3:00AM#, _
                                        New TimeSpan(-6, 0, 0))
      localTime = originalTime.ToLocalTime()
      Console.WriteLine("Converted {0} to {1}.", originalTime.ToString(), _
                                                 localTime.ToString())       

      originalTime = New DateTimeOffset(#03/11/2007 4:00AM#, _
                                        New TimeSpan(-6, 0, 0))
      localTime = originalTime.ToLocalTime()
      Console.WriteLine("Converted {0} to {1}.", originalTime.ToString(), _
                                                 localTime.ToString())       

      ' Define a summer UTC time
      originalTime = New DateTimeOffset(#6/15/2007 8:00AM#, _
                                        TimeSpan.Zero)
      localTime = originalTime.ToLocalTime()
      Console.WriteLine("Converted {0} to {1}.", originalTime.ToString(), _
                                                 localTime.ToString())       

      ' Define a winter time
      originalTime = New DateTimeOffset(#11/30/2007 2:00PM#, _
                                        New TimeSpan(3, 0, 0))
      localTime = originalTime.ToLocalTime()
      Console.WriteLine("Converted {0} to {1}.", originalTime.ToString(), _
                                                 localTime.ToString())   
      ' The example produces the following output:
      '    Converted 3/11/2007 3:00:00 AM -06:00 to 3/11/2007 1:00:00 AM -08:00.
      '    Converted 3/11/2007 4:00:00 AM -06:00 to 3/11/2007 3:00:00 AM -07:00.
      '    Converted 6/15/2007 8:00:00 AM +00:00 to 6/15/2007 1:00:00 AM -07:00.
      '    Converted 11/30/2007 2:00:00 PM +03:00 to 11/30/2007 3:00:00 AM -08:00.                                                           