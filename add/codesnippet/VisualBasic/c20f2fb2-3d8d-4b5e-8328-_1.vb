         ' Copy the EventLog entries to Array of type EventLogEntry.
         Dim myEventLogEntryArray(myEventLogEntryCollection.Count-1) As EventLogEntry
         myEventLogEntryCollection.CopyTo(myEventLogEntryArray, 0)
         Dim myEnumerator As IEnumerator = myEventLogEntryArray.GetEnumerator()
         While myEnumerator.MoveNext()
            Dim myEventLogEntry As EventLogEntry = CType(myEnumerator.Current, EventLogEntry)
            Console.WriteLine("The LocalTime the Event is generated is " + _
                                 myEventLogEntry.TimeGenerated)
         End While