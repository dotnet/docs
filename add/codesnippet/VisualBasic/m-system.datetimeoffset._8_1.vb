      Dim instanceTime As New DateTimeOffset(#10/31/2007 12:00AM#, _
                                             DateTimeOffset.Now.Offset)
      
      Dim otherTime As DateTimeOffset = instanceTime
      Console.WriteLine("{0} = {1}: {2}", _
                        instanceTime, otherTime, _
                        instanceTime.EqualsExact(otherTime))
                        
      otherTime = New DateTimeOffset(instanceTime.DateTime, _
                                     TimeSpan.FromHours(instanceTime.Offset.Hours + 1))
      Console.WriteLine("{0} = {1}: {2}", _
                        instanceTime, otherTime, _
                        instanceTime.EqualsExact(otherTime))
                        
      otherTime = New DateTimeOffset(instanceTime.DateTime + TimeSpan.FromHours(1), _
                                      TimeSpan.FromHours(instanceTime.Offset.Hours + 1))
      Console.WriteLine("{0} = {1}: {2}", _
                        instanceTime, otherTime, _
                        instanceTime.EqualsExact(otherTime))
      ' The example produces the following output:
      '       10/31/2007 12:00:00 AM -07:00 = 10/31/2007 12:00:00 AM -07:00: True
      '       10/31/2007 12:00:00 AM -07:00 = 10/31/2007 12:00:00 AM -06:00: False
      '       10/31/2007 12:00:00 AM -07:00 = 10/31/2007 1:00:00 AM -06:00: False       