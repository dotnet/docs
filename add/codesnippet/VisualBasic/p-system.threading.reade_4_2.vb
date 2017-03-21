           If Not EventLog.SourceExists("MySource") Then
               EventLog.CreateEventSource("MySource", "MyPerformanceLog")
           End If
           Dim performanceLog As New EventLog()
           performanceLog.Source = "MySource"