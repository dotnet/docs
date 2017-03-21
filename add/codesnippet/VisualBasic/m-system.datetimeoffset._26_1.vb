      Dim localTime, otherTime, universalTime As DateTimeOffset
       
      ' Define local time in local time zone
      localTime = New DateTimeOffset(#6/15/2007 12:00:00PM#)
      Console.WriteLine("Local time: {0}", localTime)
      Console.WriteLine()
      
      ' Convert local time to offset 0 and assign to otherTime
      otherTime = localTime.ToOffset(TimeSpan.Zero)
      Console.WriteLine("Other time: {0}", otherTime)
      Console.WriteLine("{0} = {1}: {2}", _
                        localTime, otherTime, _
                        localTime.Equals(otherTime))
      Console.WriteLine("{0} exactly equals {1}: {2}", _ 
                        localTime, otherTime, _
                        localTime.EqualsExact(otherTime))
      Console.WriteLine()
                        
      ' Convert other time to UTC
      universalTime = localTime.ToUniversalTime() 
      Console.WriteLine("Universal time: {0}", universalTime)
      Console.WriteLine("{0} = {1}: {2}", _
                        otherTime, universalTime, _ 
                        universalTime.Equals(otherTime))
      Console.WriteLine("{0} exactly equals {1}: {2}", _ 
                        otherTime, universalTime, _
                        universalTime.EqualsExact(otherTime))
      Console.WriteLine()
      ' The example produces the following output to the console:
      '    Local time: 6/15/2007 12:00:00 PM -07:00
      '    
      '    Other time: 6/15/2007 7:00:00 PM +00:00
      '    6/15/2007 12:00:00 PM -07:00 = 6/15/2007 7:00:00 PM +00:00: True
      '    6/15/2007 12:00:00 PM -07:00 exactly equals 6/15/2007 7:00:00 PM +00:00: False
      '    
      '    Universal time: 6/15/2007 7:00:00 PM +00:00
      '    6/15/2007 7:00:00 PM +00:00 = 6/15/2007 7:00:00 PM +00:00: True
      '    6/15/2007 7:00:00 PM +00:00 exactly equals 6/15/2007 7:00:00 PM +00:00: True   