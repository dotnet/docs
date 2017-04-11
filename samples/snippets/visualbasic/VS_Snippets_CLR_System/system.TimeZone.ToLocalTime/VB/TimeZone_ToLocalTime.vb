' Visual Basic .NET Document
Option Strict On

Imports System.Globalization

Public Module modEntryPoint
   Public Sub Main()
      
      Dim tz As New TimeZoneEx
      
      ' Select a PDT date/time
      Dim dt1 As New Date(2006, 09, 14, 6, 32, 45, DateTimeKind.Utc)
      Console.WriteLine("{0} UTC is equivalent to {1} local time.", _
                        dt1, tz.ToLocalTime(dt1))
                        
      ' Select a PST date/time
      Dim dt2 As New Date(2006, 12, 9, 11, 12, 45, DateTimeKind.Utc)
      Console.WriteLine("{0} UTC is equivalent to {1} local time.", _
                        dt2, tz.ToLocalTime(dt2))
      Console.WriteLIne("DateTime offset is {0}:{1}", tz.GetUtcOffset(Date.Now).Hours, tz.GetUtcOffset(Date.Now).Minutes)
      
      ' Select a local time
      Dim localTime1 As New Date(Date.Now.Ticks, DateTimeKind.Local)
      Console.WriteLine("{0} is equivalent to {1} UTC time.", _
                        localTime1, tz.ToUniversalTime(localTime1))
   End Sub
End Module

Public Class TimeZoneEx : Inherits TimeZone
   Private internalTimeZone As TimeZone
   
   Public Sub New()
      MyBase.New()
      internalTimeZone = TimeZone.CurrentTimeZone
   End Sub
   
   Public Overrides ReadOnly Property DaylightName() As String
      Get
         Return internalTimeZone.DaylightName
      End Get
   End Property
   
   Public Overrides ReadOnly Property StandardName() As STring
      Get
         Return internalTimeZone.StandardName
      End Get
   End Property
   
   Public Overrides Function GetDaylightChanges(year as Integer) As DaylightTime
      Return internalTimeZone.GetDaylightChanges(year)
   End Function
   
   Public Overrides Function GetUtcOffset(time As DateTime) As TimeSpan
     If time.Kind = DateTimeKind.Utc Then
        Return New TimeSpan(0, 0, 0)
     Else
        Return New TimeSpan(14, 0, 0)
     End If            
   End Function 
   
   ' <Snippet1>
   Public Overrides Function ToLocalTime(time As Date) As Date
      If time.Kind = DateTimeKind.Local Then
         Return time
      ElseIf time.Kind = DateTimeKind.Utc Then
         Dim returnTime As New Date(time.Ticks, DateTimeKind.Local)
         returnTime += me.GetUtcOffset(returnTime)
         if internalTimeZone.IsDaylightSavingTime(returnTime) Then
            returnTime -= New TimeSpan(1, 0, 0)
         End If
         Return returnTime      
      Else
         Throw New ArgumentException("The source time zone cannot be determined.")
      End If      
   End Function
   ' </Snippet1>
End Class

