   Private Function InitializeTimeZone() As TimeZoneInfo
      Dim southPole As TimeZoneInfo = Nothing
      ' Determine if South Pole time zone is defined in system
      Try
         southPole = TimeZoneInfo.FindSystemTimeZoneById("Antarctica/South Pole Standard Time")
      ' Time zone does not exist; create it, store it in a text file, and return it
      Catch e As TimeZoneNotFoundException
         Dim found As Boolean
         Const filename As String = ".\TimeZoneInfo.txt"
         
         If File.Exists(filename) Then
            Dim reader As StreamReader = New StreamReader(fileName)
            Dim timeZoneString As String
            Do While reader.Peek() >= 0
               timeZoneString = reader.ReadLine()
               If timeZoneString.Contains("Antarctica/South Pole") Then
                  southPole = TimeZoneInfo.FromSerializedString(timeZoneString)
                  reader.Close()
                  found = True
                  Exit Do
               End If   
            Loop
         End If
         If Not found Then               
            ' Define transition times to/from DST
            Dim startTransition As TimeZoneInfo.TransitionTime = TimeZoneInfo.TransitionTime.CreateFloatingDateRule(#02:00:00#, 10, 1, DayOfWeek.Sunday) 
            Dim endTransition As TimeZoneInfo.TransitionTime = TimeZoneInfo.TransitionTime.CreateFloatingDateRule(#02:00:00#, 3, 3, DayOfWeek.Sunday)
            ' Define adjustment rule
            Dim delta As TimeSpan = New TimeSpan(1, 0, 0)
            Dim adjustment As TimeZoneInfo.AdjustmentRule = TimeZoneInfo.AdjustmentRule.CreateAdjustmentRule(#10/01/1989#, Date.MaxValue.Date, delta, startTransition, endTransition)
            ' Create array for adjustment rules
            Dim adjustments() As TimeZoneInfo.AdjustmentRule = {adjustment}
            ' Define other custom time zone arguments
            Dim displayName As String = "(GMT+12:00) Antarctica/South Pole"
            Dim standardName As String = "Antarctica/South Pole Standard Time"
            Dim daylightName As String = "Antarctica/South Pole Daylight Time"
            Dim offset As TimeSpan = New TimeSpan(12, 0, 0)
            southPole = TimeZoneInfo.CreateCustomTimeZone(standardName, offset, displayName, standardName, daylightName, adjustments)
            ' Write time zone to the file
            Dim writer As StreamWriter = New StreamWriter(filename, True)
            writer.WriteLine(southPole.ToSerializedString())
            writer.Close()
         End If
      End Try
      Return southPole
   End Function