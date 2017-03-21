      Dim timeZones As ReadOnlyCollection(Of TimeZoneInfo) = TimeZoneInfo.GetSystemTimeZones()
      Dim timeZoneArray(timeZones.Count - 1) As TimeZoneInfo
      timeZones.CopyTo(timeZoneArray, 0) 
      'Dim arrayPtr As Integer = 1
      ' Iterate array from top to bottom
      For ctr As Integer = timeZoneArray.GetUpperBound(0) To 1 Step -1
         ' Get next item from top
         Dim thisTimeZone As TimeZoneInfo = timeZoneArray(ctr)
         For compareCtr As Integer = 0 To ctr - 1
            ' Determine if time zones have the same rules
            If thisTimeZone.HasSameRules(timeZoneArray(compareCtr)) Then
               Console.WriteLine("{0} has the same rules as {1}", _
                                 thisTimeZone.StandardName, _
                                 timeZoneArray(compareCtr).StandardName)
            End If                     
         Next      
      Next