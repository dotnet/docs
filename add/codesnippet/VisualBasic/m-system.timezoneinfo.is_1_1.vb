      Dim unclearDate As Date = #11/4/2007 1:30AM#
      ' Test if time is ambiguous.
      Console.WriteLine("In the {0}, {1} is {2}ambiguous.", _ 
                        TimeZoneInfo.Local.DisplayName, _
                        unclearDate, _
                        IIf(TimeZoneInfo.Local.IsAmbiguousTime(unclearDate), "", "not "))
      ' Test if time is DST.
      Console.WriteLine("In the {0}, {1} is {2}daylight saving time.", _ 
                        TimeZoneInfo.Local.DisplayName, _
                        unclearDate, _
                        IIf(TimeZoneInfo.Local.IsDaylightSavingTime(unclearDate), "", "not "))
      Console.WriteLine()    
      ' Report time as DST if it is either ambiguous or DST.
      If TimeZoneInfo.Local.IsAmbiguousTime(unclearDate) OrElse _ 
         TimeZoneInfo.Local.IsDaylightSavingTime(unclearDate) Then
          Console.WriteLine("{0} may be daylight saving time in {1}.", _ 
                            unclearDate, TimeZoneInfo.Local.DisplayName)                                           
      End If
      ' The example displays the following output:
      '    In the (GMT-08:00) Pacific Time (US & Canada), 11/4/2007 1:30:00 AM is ambiguous.
      '    In the (GMT-08:00) Pacific Time (US & Canada), 11/4/2007 1:30:00 AM is not daylight saving time.
      '    
      '    11/4/2007 1:30:00 AM may be daylight saving time in (GMT-08:00) Pacific Time (US & Canada).