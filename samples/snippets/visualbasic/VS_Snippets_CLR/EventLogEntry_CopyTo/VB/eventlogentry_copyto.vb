' System.Diagnostics.EventLogEntryCollection
' System.Diagnostics.EventLogEntryCollection.CopyTo(EventLogEntry[],int)

' The following example demonstrates the EventLogEntryCollection class and the
' CopyTo method of EventLogEntryCollection class.A new Source for eventlog 'MyNewLog'
' is created.A new entry is created for 'MyNewLog'.The entries of EventLog are copied
' to an Array.

' <Snippet1>
Imports System
Imports System.Collections
Imports System.Diagnostics

Class EventLogEntryCollection_Item
   Public Shared Sub Main()
      Try
         Dim myLogName As String = "MyNewlog"
         ' Check if the source exists.
         If Not EventLog.SourceExists("MySource") Then
            'Create source.
            EventLog.CreateEventSource("MySource", myLogName)
            Console.WriteLine("Creating EventSource")
         ' Get the EventLog associated if the source exists.
         Else
            myLogName = EventLog.LogNameFromSourceName("MySource", ".")
         End If
         ' Create an EventLog instance and assign its source.
         Dim myEventLog2 As New EventLog()
         myEventLog2.Source = "MySource"
         ' Write an informational entry to the event log.
         myEventLog2.WriteEntry("Successfully created a new Entry in the Log")
         myEventLog2.Close()
         ' Create a new EventLog object.
         Dim myEventLog1 As New EventLog()
         myEventLog1.Log = myLogName

         ' Obtain the Log Entries of "MyNewLog".
         Dim myEventLogEntryCollection As EventLogEntryCollection = myEventLog1.Entries
         myEventLog1.Close()
         Console.WriteLine("The number of entries in 'MyNewLog' = " + _
                           myEventLogEntryCollection.Count.ToString())

         ' Display the 'Message' property of EventLogEntry.
         Dim i As Integer
         For i = 0 To myEventLogEntryCollection.Count - 1
            Console.WriteLine("The Message of the EventLog is :" + _
                              myEventLogEntryCollection(i).Message)
         Next i
' <Snippet2>
         ' Copy the EventLog entries to Array of type EventLogEntry.
         Dim myEventLogEntryArray(myEventLogEntryCollection.Count-1) As EventLogEntry
         myEventLogEntryCollection.CopyTo(myEventLogEntryArray, 0)
         Dim myEnumerator As IEnumerator = myEventLogEntryArray.GetEnumerator()
         While myEnumerator.MoveNext()
            Dim myEventLogEntry As EventLogEntry = CType(myEnumerator.Current, EventLogEntry)
            Console.WriteLine("The LocalTime the Event is generated is " + _
                                 myEventLogEntry.TimeGenerated)
         End While
' </Snippet2>
      Catch e As Exception
         Console.WriteLine("Exception:{0}", e.Message.ToString())
      End Try
   End Sub 'Main
End Class 'EventLogEntryCollection_Item
' </Snippet1>
