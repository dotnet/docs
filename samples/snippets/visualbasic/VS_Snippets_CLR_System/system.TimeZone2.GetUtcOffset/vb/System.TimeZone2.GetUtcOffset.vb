' Visual Basic .NET Document
' <Snippet1>
Option Strict On

<Assembly: CLSCompliant(True)>
Module TimeOffsets
   Public Sub Main()
      Dim cst As TimeZoneInfo = TimeZoneInfo.FindSystemTimeZoneById("Central Standard Time")

      ShowOffset(#6/12/2006 11:00AM#, TimeZoneInfo.Local)
      ShowOffset(#11/4/2007 1:00AM#, TimeZoneInfo.Local)
      ShowOffset(#12/10/2006 3:00PM#, TimeZoneInfo.Local)
      ShowOffset(#3/11/2007 2:30:00AM#, TimeZoneInfo.Local)
      ShowOffset(Date.UtcNow, TimeZoneInfo.Local)
      ShowOffset(#6/12/2006 11:00AM#, TimeZoneInfo.Utc)
      ShowOffset(#11/4/2007 1:00AM#, TimeZoneInfo.Utc)
      ShowOffset(#12/10/2006 3:00PM#, TimeZoneInfo.Utc)
      ShowOffset(#3/11/2007 2:30:00AM#, TimeZoneInfo.Utc)
      ShowOffset(Date.Now, TimeZoneInfo.Utc)
      ShowOffset(#6/12/2006 11:00AM#, cst)
      ShowOffset(#11/4/2007 1:00AM#, cst)
      ShowOffset(#12/10/2006 3:00PM#, cst)
      ShowOffset(#3/11/2007 2:30:00AM#, cst)
      ShowOffset(New Date(2007, 11, 14, 00, 00, 00, DateTimeKind.Local), cst)
   End Sub
   
   Private Sub ShowOffset(time As Date, timeZone As TimeZoneInfo)
      Dim convertedTime As Date = time  
      Dim offset As TimeSpan
      
      If time.Kind = DateTimeKind.Local And Not timeZone.Equals(TimeZoneInfo.Local) Then
         convertedTime = TimeZoneInfo.ConvertTime(time, TimeZoneInfo.Local, timeZone)
      ElseIf time.Kind = DateTimeKind.Utc And Not timeZone.Equals(TimeZoneInfo.Utc) Then
         convertedTime = TimeZoneInfo.ConvertTime(time, TimeZoneInfo.Utc, timeZone)         
      End If
      offset = timeZone.GetUtcOffset(time)
      If time = convertedTime Then
         Console.WriteLine("{0} {1} ", time, _
                           IIf(timeZone.IsDaylightSavingTime(time), timeZone.DaylightName, timeZone.StandardName))
         Console.WriteLine("   It differs from UTC by {0} hours, {1} minutes.", _
                            offset.Hours, _
                            offset.Minutes)
      Else
         Console.WriteLine("{0} {1} ", time, _
                           IIf(time.Kind = DateTimeKind.Utc, "UTC", TimeZoneInfo.Local.Id))       
         Console.WriteLine("   converts to {0} {1}.", _
                           convertedTime, _
                           timeZone.Id)
         Console.WriteLine("   It differs from UTC by {0} hours, {1} minutes.", _
                           offset.Hours, offset.Minutes)  
       End If
       Console.WriteLine()                                             
   End Sub
End Module
'
' The example produces the following output:
' 
'       6/12/2006 11:00:00 AM Pacific Daylight Time 
'          It differs from UTC by -7 hours, 0 minutes.
'       
'       11/4/2007 1:00:00 AM Pacific Standard Time 
'          It differs from UTC by -8 hours, 0 minutes.
'       
'       12/10/2006 3:00:00 PM Pacific Standard Time 
'          It differs from UTC by -8 hours, 0 minutes.
'       
'       3/11/2007 2:30:00 AM Pacific Standard Time 
'          It differs from UTC by -8 hours, 0 minutes.
'       
'       2/2/2007 8:35:46 PM UTC 
'          converts to 2/2/2007 12:35:46 PM Pacific Standard Time.
'          It differs from UTC by -8 hours, 0 minutes.
'       
'       6/12/2006 11:00:00 AM UTC 
'          It differs from UTC by 0 hours, 0 minutes.
'       
'       11/4/2007 1:00:00 AM UTC 
'          It differs from UTC by 0 hours, 0 minutes.
'       
'       12/10/2006 3:00:00 AM UTC 
'          It differs from UTC by 0 hours, 0 minutes.
'       
'       3/11/2007 2:30:00 AM UTC 
'          It differs from UTC by 0 hours, 0 minutes.
'       
'       2/2/2007 12:35:46 PM Pacific Standard Time 
'          converts to 2/2/2007 8:35:46 PM UTC.
'          It differs from UTC by 0 hours, 0 minutes.
'       
'       6/12/2006 11:00:00 AM Central Daylight Time 
'          It differs from UTC by -5 hours, 0 minutes.
'       
'       11/4/2007 1:00:00 AM Central Standard Time 
'          It differs from UTC by -6 hours, 0 minutes.
'       
'       12/10/2006 3:00:00 PM Central Standard Time 
'          It differs from UTC by -6 hours, 0 minutes.
'       
'       3/11/2007 2:30:00 AM Central Standard Time 
'          It differs from UTC by -6 hours, 0 minutes.
'       
'       11/14/2007 12:00:00 AM Pacific Standard Time 
'          converts to 11/14/2007 2:00:00 AM Central Standard Time.
'          It differs from UTC by -6 hours, 0 minutes.
' </Snippet1>
