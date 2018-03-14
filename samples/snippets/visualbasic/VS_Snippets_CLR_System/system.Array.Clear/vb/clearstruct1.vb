' Visual Basic .NET Document
'Option Strict On

' <Snippet2>
Public Structure TimeZoneTime
   Private dt As DateTimeOffset
   Private tz As TimeZoneInfo
   
   Public Sub New(dateTime As DateTimeOffset, timeZone As TimeZoneInfo)
      dt = dateTime
      tz = timeZone
   End Sub

   Public ReadOnly Property DateTime As DateTimeOffset
      Get
         Return dt
      End Get
   End Property
   
   Public ReadOnly Property TimeZone As TimeZoneInfo
      Get
         Return tz
      End Get
   End Property 
End Structure

Module Example
   Public Sub Main()
      ' Declare an array with two elements.
      Dim timeZoneTimes() As TimeZoneTime = { New TimeZoneTime(Date.Now, TimeZoneInfo.Local),
                                              New TimeZoneTime(Date.Now, TimeZoneInfo.Utc) }   
      For Each timeZoneTime In timeZoneTimes
         Console.WriteLine("{0}: {1:G}", 
                           If(timeZoneTime.TimeZone Is Nothing, "<null>", timeZoneTime.TimeZone), 
                           timeZoneTime.DateTime)
      Next
      Console.WriteLine()
      
      Array.Clear(timeZoneTimes, 1, 1)
      For Each timeZoneTime In timeZoneTimes
         Console.WriteLine("{0}: {1:G}", 
                           If(timeZoneTime.TimeZone Is Nothing, "<null>", timeZoneTime.TimeZone), 
                           timeZoneTime.DateTime)
      Next
   End Sub
End Module
' The example displays output like the following:
'       (UTC-08:00) Pacific Time (US & Canada): 1/20/2014 12:11:00 PM
'       UTC: 1/20/2014 12:11:00 PM
'       
'       (UTC-08:00) Pacific Time (US & Canada): 1/20/2014 12:11:00 PM
'       <null>: 1/1/0001 12:00:00 AM
' </Snippet2>
