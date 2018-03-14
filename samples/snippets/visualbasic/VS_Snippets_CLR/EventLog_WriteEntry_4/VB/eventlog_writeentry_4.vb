' System.Diagnostics.EventLog.WriteEntry(String,String,EventLogEntryType,Int32)

' The following sample demonstrates the 
' 'WriteEntry(String,String,EventLogEntryType,Int32)' method of 
' 'EventLog' class. It writes an entry to a custom event log, "MyNewLog".
' It creates the source "MySource" if the source does not already exist.

Imports System
Imports System.Diagnostics

Class EventLog_WriteEntry_4
   Public Shared Sub Main()
      Try
' <Snippet1>
         ' Create the source, if it does not already exist.
         If Not EventLog.SourceExists("MySource") Then
            EventLog.CreateEventSource("MySource", "myNewLog")
            Console.WriteLine("Creating EventSource")
         End If
         
         ' Set the 'description' for the event.
         Dim myMessage As String = "This is my event."
         Dim myEventLogEntryType As EventLogEntryType = EventLogEntryType.Warning
         Dim myApplicationEventId As Integer = 100
         
         ' Write the entry in the event log.
         Console.WriteLine("Writing to EventLog.. ")
         EventLog.WriteEntry("MySource", myMessage, myEventLogEntryType, myApplicationEventId)
' </Snippet1>        
      Catch e As Exception
         Console.WriteLine("Exception:{0}", e.Message.ToString())
      End Try
   End Sub 'Main
End Class 'EventLog_WriteEntry_4