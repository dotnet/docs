         ' Create a new EventLog object.
         Dim myEventLog1 As New EventLog()
         myEventLog1.Log = myLogName
         ' Obtain the Log Entries of the Event Log
         Dim myEventLogEntryCollection As EventLogEntryCollection = myEventLog1.Entries
         Console.WriteLine("The number of entries in 'MyNewLog' = " + _
                                    myEventLogEntryCollection.Count.ToString())
         ' Display the 'Message' property of EventLogEntry.
         Dim i As Integer
         For i = 0 To myEventLogEntryCollection.Count - 1
            Console.WriteLine("The Message of the EventLog is :" + _
                           myEventLogEntryCollection(i).Message)
         Next i