   Protected Shared Sub MyOnEntry(source As Object, e As EntryWrittenEventArgs)
      Dim myEventLogEntry As EventLogEntry = e.Entry
      If Not (myEventLogEntry Is Nothing) Then
         Console.WriteLine("Current message entry is: '" + _
                                             myEventLogEntry.Message + "'")
      Else
         Console.WriteLine("The current entry is null")
      End If
   End Sub 'MyOnEntry