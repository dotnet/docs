' Visual Basic .NET Document
Option Strict On

' <Snippet2>
Module Example
   Public Sub Main()
      ' Define times to be converted.
      Dim time1 As Date = #1/1/2010 12:01AM#
      Dim time2 As Date = #11/6/2010 11:30PM#
      Dim times() As DateTimeOffset = { New DateTimeOffset(time1, TimeZoneInfo.Local.GetUtcOffset(time1)), _
                                        New DateTimeOffset(time1, Timespan.Zero), _
                                        New DateTimeOffset(time2, TimeZoneInfo.Local.GetUtcOffset(time2)), _
                                        New DateTimeOffset(time2.AddHours(3), TimeZoneInfo.Local.GetUtcOffset(time2.AddHours(3))) }
                              
      ' Retrieve the time zone for Eastern Standard Time (U.S. and Canada).
      Dim est As TimeZoneInfo 
      Try
         est = TimeZoneInfo.FindSystemTimeZoneById("Eastern Standard Time")
      Catch e As TimeZoneNotFoundException
         Console.WriteLine("Unable to retrieve the Eastern Standard time zone.")
         Exit Sub
      Catch e As InvalidTimeZoneException
         Console.WriteLine("Unable to retrieve the Eastern Standard time zone.")
         Exit Sub
      End Try   

      ' Display the current time zone name.
      Console.WriteLine("Local time zone: {0}", TimeZoneInfo.Local.DisplayName)
      Console.WriteLine()
      
      ' Convert each time in the array.
      For Each timeToConvert As DateTimeOffset In times
         Dim targetTime As DateTimeOffset = TimeZoneInfo.ConvertTime(timeToConvert, est)
         Console.WriteLine("Converted {0} to {1}.", timeToConvert, targetTime)
      Next                        
   End Sub
End Module
' The example displays the following output:
'    Local time zone: (GMT-08:00) Pacific Time (US & Canada)
'    
'    Converted 1/1/2010 12:01:00 AM -08:00 to 1/1/2010 3:01:00 AM -05:00.
'    Converted 1/1/2010 12:01:00 AM +00:00 to 12/31/2009 7:01:00 PM -05:00.
'    Converted 11/6/2010 11:30:00 PM -07:00 to 11/7/2010 1:30:00 AM -05:00.
'    Converted 11/7/2010 2:30:00 AM -08:00 to 11/7/2010 5:30:00 AM -05:00.
' </Snippet2>
