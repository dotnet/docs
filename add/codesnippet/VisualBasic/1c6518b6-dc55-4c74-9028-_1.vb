         ' Create the source, if it does not already exist.
         dim myLogName as string = "myNewLog"
         If Not EventLog.SourceExists("MySource") Then
            EventLog.CreateEventSource("MySource", myLogName)
            Console.WriteLine("Creating EventSource")
         else
            myLogName = EventLog.LogNameFromSourceName("MySource",".")
         End If
         
         ' Create an EventLog and assign source.
         Dim myEventLog As New EventLog()
         myEventLog.Source = "MySource"
         myEventLog.Log = myLogName
         
         ' Set the 'description' for the event.
         Dim myMessage As String = "This is my event."
         Dim myEventLogEntryType As EventLogEntryType = EventLogEntryType.Warning
         Dim myApplicatinEventId As Integer = 1100
         Dim myApplicatinCategoryId As Short = 1
         
         ' Set the 'data' for the event.
         Dim myRawData(3) As Byte
         Dim i As Integer
         For i = 0 To 3
            myRawData(i) = 1
         Next i
         ' Write the entry in the event log.
         Console.WriteLine("Writing to EventLog.. ")
         myEventLog.WriteEntry(myMessage, myEventLogEntryType, myApplicatinEventId, _
                              myApplicatinCategoryId, myRawData)