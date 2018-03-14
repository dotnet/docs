' System.Diagnostics.EntryWrittenEventArgs.ctor()

' The following example demonstrates 'EntryWrittenEventArgs ()'
' constructor of the 'EntryWrittenEventArgs' class. It creates a custom 'EventLog'
' and writes an entry into it. Then creates an 'EntryWrittenEventArgs' object
' using the first entry in the custom eventlog.This object is used to notify a message

' <Snippet1>
Imports System
Imports System.Diagnostics

Class MySample
   Public Shared Sub Main()
      Try
         Dim myNewLog As New EventLog()
         myNewLog.Log = "MyNewLog"
         myNewLog.Source = "MySource"
         ' Create the source if it does not exist already.
         If Not EventLog.SourceExists("MySource") Then
            EventLog.CreateEventSource("MySource", "MyNewLog")
            Console.WriteLine("CreatingEventSource")
         End If
         ' Write an entry to the EventLog.
         myNewLog.WriteEntry("The Latest entry in the Event Log")
         Dim myEntryEventArgs As EntryWrittenEventArgs = _
                                    New EntryWrittenEventArgs()
         MyOnEntry(myNewLog, myEntryEventArgs)
      Catch e As Exception
         Console.WriteLine("Exception Raised" + e.Message)
      End Try
   End Sub 'Main
   Protected Shared Sub MyOnEntry(ByVal source As Object, _
                                  ByVal e As EntryWrittenEventArgs)
      If e.Entry Is Nothing Then
          Console.WriteLine("A new entry is written in MyNewLog.")
      End If
   End Sub 'MyOnEntry
End Class 'MySample
' </Snippet1>
