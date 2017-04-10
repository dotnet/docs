' System.Diagnostics.EventLogEntryCollection.Count
' System.Diagnostics.EventLogEntryCollection.Item

' The following example demonstrates 'Item','Count' properties of 
' EventLogEntryCollection class.A new Source for eventlog 'MyNewLog' is created.
' The program checks if a Event source exists.If the source already exists, it gets 
' the Log name associated with it otherwise, creates a new event source. 
' A new entry is created for 'MyNewLog'.Entries  of 'MyNewLog' are obtained and 
' the count and the messages are  displayed.

Imports System
Imports System.Collections
Imports System.Diagnostics

Class EventLogEntryCollection_Item
   
   Public Shared Sub Main()
      Try
         Dim myLogName As String = "MyNewLog"
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
         'Write an entry to the event log.
         myEventLog2.WriteEntry("Successfully created a new Entry in the Log. ")
' <Snippet1>
' <Snippet2>
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
' </Snippet2>
' </Snippet1>
      Catch e As Exception
         Console.WriteLine("Exception Caught!" + e.Message.ToString())
      End Try
   End Sub 'Main
End Class 'EventLogEntryCollection_Item