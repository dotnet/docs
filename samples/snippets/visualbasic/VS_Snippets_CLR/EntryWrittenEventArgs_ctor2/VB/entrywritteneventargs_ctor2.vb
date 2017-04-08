' System.Diagnostics.EntryWrittenEventArgs.ctor(EventLogEntry)
' System.Diagnostics.EntryWrittenEventArgs.Entry

' The following example demonstrates the 'Entry' property and
' EntryWrittenEventArgs (EventLogEntry) constructor of the
' 'EntryWrittenEventArgs' class. It creates a custom 'EventLog' and writes an
' entry into it. Then creates an 'EntryWrittenEventArgs' object using the
' first entry in the custom eventlog.This object is used to notify a message

' <Snippet1>
Imports System
Imports System.Diagnostics

Class MySample
   Public Shared Sub Main()
      Try
         Dim myNewLog As New EventLog()
         ' Create the source if it does not exist already.
         If Not EventLog.SourceExists("MySource") Then
            EventLog.CreateEventSource("MySource", "MyNewLog")
            Console.WriteLine("CreatingEventSource")
         End If
         myNewLog.Log = "MyNewLog"
         myNewLog.Source = "MySource"
         ' Write an entry to the EventLog.
         myNewLog.WriteEntry("The Latest entry in the Event Log")

         Dim myEntries As Integer = myNewLog.Entries.Count
         Dim entry As EventLogEntry = myNewLog.Entries(myEntries - 1)
         Dim myEntryEventArgs As New EntryWrittenEventArgs(entry)
         MyOnEntry(myNewLog, myEntryEventArgs)
      Catch e As Exception
         Console.WriteLine("Exception Raised" + e.Message)
      End Try
   End Sub 'Main

' <Snippet2>
   Protected Shared Sub MyOnEntry(source As Object, e As EntryWrittenEventArgs)
      Dim myEventLogEntry As EventLogEntry = e.Entry
      If Not (myEventLogEntry Is Nothing) Then
         Console.WriteLine("Current message entry is: '" + _
                                             myEventLogEntry.Message + "'")
      Else
         Console.WriteLine("The current entry is null")
      End If
   End Sub 'MyOnEntry
' </Snippet2>
End Class 'MySample
' </Snippet1>
