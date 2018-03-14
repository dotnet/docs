' Visual Basic .NET Document
Option Strict On

' <Snippet2>     
Module Example
   Public Sub Main()
      ' Get time in local time zone 
      Dim thisTime As Date = Date.Now
      Console.WriteLine("Time in {0} zone: {1}", IIf(TimeZoneInfo.Local.IsDaylightSavingTime(thisTime), 
                        TimeZoneInfo.Local.DaylightName, TimeZoneInfo.Local.StandardName), thisTime)
      Console.WriteLine("   UTC Time: {0}", TimeZoneInfo.ConvertTimeToUtc(thisTime, TimeZoneInfo.Local))
      ' Get Tokyo Standard Time zone
      Dim tst As TimeZoneInfo = TimeZoneInfo.FindSystemTimeZoneById("Tokyo Standard Time")
      Dim tstTime As Date = TimeZoneInfo.ConvertTime(thisTime, TimeZoneInfo.Local, tst)      
      Console.WriteLine("Time in {0} zone: {1}", IIf(tst.IsDaylightSavingTime(tstTime), 
                        tst.DaylightName, tst.StandardName), tstTime)
      Console.WriteLine("   UTC Time: {0}", TimeZoneInfo.ConvertTimeToUtc(tstTime, tst))
   End Sub
End Module
' The example displays output like the following when run on a system in the U.S.
' Pacific Standard Time zone:
'    Time in Pacific Standard Time zone: 12/6/2013 10:57:51 AM
'       UTC Time: 12/6/2013 6:57:51 PM
'    Time in Tokyo Standard Time zone: 12/7/2013 3:57:51 AM
'       UTC Time: 12/6/2013 6:57:51 PM
' </Snippet2>
