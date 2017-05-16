' Visual Basic .NET Document
Option Strict On

' <Snippet1>
Module Example
   Public Sub Main()
      ' Define times to be converted.
      Dim times() As Date = { #1/1/2010 12:01AM#, _
                              DateTime.SpecifyKind(#1/1/2010 12:01AM#, DateTimeKind.Utc), _
                              DateTime.SpecifyKind(#1/1/2010 12:01AM#, DateTimeKind.Local), _
                              #11/6/2010 11:30PM#, #11/7/2010 2:30AM# }
                              
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
      For Each timeToConvert As Date In times
         Dim targetTime As Date = TimeZoneInfo.ConvertTime(timeToConvert, est)
         Console.WriteLine("Converted {0} {1} to {2}.", timeToConvert, _
                           timeToConvert.Kind, targetTime)
      Next                        
   End Sub
End Module
' The example displays the following output:
'    Local time zone: (GMT-08:00) Pacific Time (US & Canada)
'    
'    Converted 1/1/2010 12:01:00 AM Unspecified to 1/1/2010 3:01:00 AM.
'    Converted 1/1/2010 12:01:00 AM Utc to 12/31/2009 7:01:00 PM.
'    Converted 1/1/2010 12:01:00 AM Local to 1/1/2010 3:01:00 AM.
'    Converted 11/6/2010 11:30:00 PM Unspecified to 11/7/2010 1:30:00 AM.
'    Converted 11/7/2010 2:30:00 AM Unspecified to 11/7/2010 5:30:00 AM.
' </Snippet1>
