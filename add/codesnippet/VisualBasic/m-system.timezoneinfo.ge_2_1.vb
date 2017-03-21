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