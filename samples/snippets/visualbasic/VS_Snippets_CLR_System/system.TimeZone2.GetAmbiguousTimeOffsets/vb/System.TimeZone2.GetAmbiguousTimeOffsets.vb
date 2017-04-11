' Visual Basic .NET Document
Option Strict On

<Assembly: CLSCompliant(True)>
Module modMain

   Public Sub Main()
      Console.WriteLine()
      ' <Snippet2>
      ShowPossibleUtcTimes(#11/4/2007 1:00:00#, TimeZoneInfo.FindSystemTimeZoneById("Central Standard Time"))
      Console.WriteLine()
      ShowPossibleUtcTimes(New Date(2007, 11, 4, 01, 00, 00, DateTimeKind.Local), _
                           TimeZoneInfo.FindSystemTimeZoneById("Central Standard Time"))
      Console.WriteLine()
      ShowPossibleUtcTimes(New Date(2007, 11, 4, 00, 00, 00, DateTimeKind.Local), _
                           TimeZoneInfo.FindSystemTimeZoneById("Central Standard Time"))
      Console.WriteLine()                     
      ShowPossibleUtcTimes(New Date(2007, 11, 4, 01, 00, 00, DateTimeKind.Unspecified), _
                           TimeZoneInfo.FindSystemTimeZoneById("Central Standard Time"))
      Console.WriteLine()
      ShowPossibleUtcTimes(New Date(2007, 11, 4, 07, 00, 00, DateTimeKind.Utc), _
                           TimeZoneInfo.FindSystemTimeZoneById("Central Standard Time"))
      ' 
      ' This example produces the following output if run in the Pacific time zone:
      '
      '    11/4/2007 1:00:00 AM (GMT-06:00) Central Time (US & Canada) maps to the following possible times:
      '    If 11/4/2007 1:00:00 AM is Central Standard Time, 11/4/2007 7:00:00 AM UTC
      '    If 11/4/2007 1:00:00 AM is Central Daylight Time, 11/4/2007 6:00:00 AM UTC
      ' 
      '    11/4/2007 1:00:00 AM Pacific Standard Time is not ambiguous in time zone (GMT-06:00) Central Time (US & Canada).
      ' 
      '    11/4/2007 12:00:00 AM local time maps to the following possible times:
      '    If 11/4/2007 1:00:00 AM is Central Standard Time, 11/4/2007 7:00:00 AM UTC
      '    If 11/4/2007 1:00:00 AM is Central Daylight Time, 11/4/2007 6:00:00 AM UTC
      ' 
      '    11/4/2007 1:00:00 AM (GMT-06:00) Central Time (US & Canada) maps to the following possible times:
      '    If 11/4/2007 1:00:00 AM is Central Standard Time, 11/4/2007 7:00:00 AM UTC
      '    If 11/4/2007 1:00:00 AM is Central Daylight Time, 11/4/2007 6:00:00 AM UTC
      ' 
      '    11/4/2007 7:00:00 AM UTC maps to the following possible times:
      '    If 11/4/2007 1:00:00 AM is Central Standard Time, 11/4/2007 7:00:00 AM UTC
      '    If 11/4/2007 1:00:00 AM is Central Daylight Time, 11/4/2007 6:00:00 AM UTC
      ' </Snippet2>                     
   End Sub
   
   Private Sub ShowArray()
      Dim ambiguousDate As Date = #10/29/2006 1:00:00#
      Dim cst As TimeZoneInfo = TimeZoneInfo.FindSystemTimeZoneById("Central Standard Time")
      Console.WriteLine("{0} is{1} ambiguous in the {2} zone.", _
                        ambiguousDate, _ 
                        IIf(cst.IsAmbiguousTime(ambiguousDate), "", " not"), _
                        cst.StandardName)
      Dim retArray() As TimeSpan = cst.GetAmbiguousTimeOffsets(ambiguousDate)
      Console.WriteLine("Array has {0} elements:", retArray.Length) 
      For each offset As TimeSpan In retArray
         Console.WriteLine("   {0} hours, {1} minutes, {2} seconds", offset.Hours, offset.Minutes, offset.Seconds)
      Next                 
   End Sub

   ' <Snippet1>
   Private Sub ShowPossibleUtcTimes(ambiguousTime As Date, timeZone As TimeZoneInfo)
      ' Determine if time is ambiguous in target time zone
      If Not timeZone.IsAmbiguousTime(ambiguousTime) Then
         Console.WriteLine("{0} is not ambiguous in time zone {1}.", _
                           ambiguousTime, _
                           timeZone.DisplayName)
      Else
         ' Display time and its time zone (local, UTC, or indicated by timeZone argument)
         Dim originalTimeZoneName As String 
         If ambiguousTime.Kind = DateTimeKind.Utc Then
            originalTimeZoneName = "UTC"
         ElseIf ambiguousTime.Kind = DateTimeKind.Local Then
            originalTimeZoneName = "local time"
         Else
            originalTimeZoneName = timeZone.DisplayName
         End If      
         Console.WriteLine("{0} {1} maps to the following possible times:", _
                           ambiguousTime, originalTimeZoneName)
         ' Get ambiguous offsets 
         Dim offsets() As TimeSpan = timeZone.GetAmbiguousTimeOffsets(ambiguousTime)
         ' Handle times not in time zone of timeZone argument
         ' Local time where timeZone is not local zone
         If (ambiguousTime.Kind = DateTimeKind.Local) And Not timeZone.Equals(TimeZoneInfo.Local) Then
            ambiguousTime = TimeZoneInfo.ConvertTime(ambiguousTime, TimeZoneInfo.Local, timeZone)
         ' UTC time where timeZone is not UTC zone   
         ElseIf (ambiguousTime.Kind = DateTimeKind.Utc) And Not timeZone.Equals(TimeZoneInfo.Utc) Then
            ambiguousTime = TimeZoneInfo.ConvertTime(ambiguousTime, TimeZoneInfo.Utc, timeZone)
         End If       
         ' Display each offset and its mapping to UTC
         For Each offset As TimeSpan In offsets
            If offset.Equals(timeZone.BaseUtcOffset) Then
               Console.WriteLine("If {0} is {1}, {2} UTC", ambiguousTime, timeZone.StandardName, ambiguousTime - offset)
            Else
               Console.WriteLine("If {0} is {1}, {2} UTC", ambiguousTime, timeZone.DaylightName, ambiguousTime - offset)
            End If   
         Next
      End If            
   End Sub
   ' </Snippet1>
   
   Private Sub TestPossibleUtcTimes(ambiguousTime As Date, timeZone As TimeZoneInfo)
         Dim originalTimeZoneName As String 
         If ambiguousTime.Kind = DateTimeKind.Utc Then
            originalTimeZoneName = "UTC"
         ElseIf ambiguousTime.Kind = DateTimeKind.Local Then
            originalTimeZoneName = "local time"
         Else
            originalTimeZoneName = timeZone.DisplayName
         End If      
         Console.WriteLine("{0} {1} maps to the following possible times:", _
                           ambiguousTime, originalTimeZoneName)
   
''      Console.WriteLine("Possible UTC times for {0} {1}", ambiguousTime, timeZone.DisplayName)
      Try
         Dim offsets() As TimeSpan = timeZone.GetAmbiguousTimeOffsets(ambiguousTime)
         For Each offset As TimeSpan In offsets
            If (ambiguousTime.Kind = DateTimeKind.Local) And Not timeZone.Equals(TimeZoneInfo.Local) Then
               ambiguousTime = TimeZoneInfo.ConvertTime(ambiguousTime, TimeZoneInfo.Local, timeZone)
            ElseIf (ambiguousTime.Kind = DateTimeKind.Utc) And Not timeZone.Equals(TimeZoneInfo.Utc) Then
               ambiguousTime = TimeZoneInfo.ConvertTime(ambiguousTime, TimeZoneInfo.Utc, timeZone)
            End If       
            If offset.Equals(timeZone.BaseUtcOffset) Then
               Console.WriteLine("If {0} is {1}, {2} UTC", ambiguousTime, timeZone.StandardName, ambiguousTime - offset)
            Else
               Console.WriteLine("If {0} is {1}, {2} UTC", ambiguousTime, timeZone.DaylightName, ambiguousTime - offset)
            End If   
         Next
      Catch e As Exception
         Console.WriteLine(e.GetType().Name & ": " & e.Message)
      End Try   
   End Sub
End Module

