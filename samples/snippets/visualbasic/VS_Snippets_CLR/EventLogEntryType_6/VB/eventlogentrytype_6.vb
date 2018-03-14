' System.Diagnostics.EventLogEntryType
' System.Diagnostics.EventLogEntryType.Error
' System.Diagnostics.EventLogEntryType.Warning
' System.Diagnostics.EventLogEntryType.Information
' System.Diagnostics.EventLogEntryType.FailureAudit
' System.Diagnostics.EventLogEntryType.SuccessAudit

' The following program demonstrates 'Error', 'Warning', 
' 'Information', 'FailureAudit' and 'SuccessAudit' members of 
' 'EventLogEntryType' enumerator. It creates new source with a 
' specified event log, new ID, EventLogEntryType and message,
' if does not exist.

' <Snippet1>
Imports System
Imports System.Diagnostics
Imports System.Runtime.Serialization

Class MyEventLogEntryType
   Public Shared Sub Main()
      Try
         Dim myEventLog As EventLog
         Dim mySource As String = Nothing
         Dim myLog As String = Nothing
         Dim myType As String = Nothing
         Dim myMessage As String = "A new event is created."
         Dim myEventID As String = Nothing
         Dim myIntLog As Integer = 0
         Dim myID As Integer = 0
         Console.Write("Enter source name for new event (eg: Print ): ")
         mySource = Console.ReadLine()
         Console.Write("Enter log name in which to write an event( eg: System ): ")
         myLog = Console.ReadLine()
         Console.WriteLine("")
         Console.WriteLine("     Select type of event to write:")
         Console.WriteLine("       1.     Error ")
         Console.WriteLine("       2.     Warning")
         Console.WriteLine("       3.     Information")
         Console.WriteLine("       4.     FailureAudit")
         Console.WriteLine("       5.     SuccessAudit")
         Console.Write("Enter the choice(eg. 1): ")
         myType = Console.ReadLine()
         myIntLog = Convert.ToInt32(myType)
         Console.Write("Enter ID with which to write an event( eg: 0-65535 ): ")
         myEventID = Console.ReadLine()
         myID = Convert.ToInt32(myEventID)
' <Snippet2>
         ' Check whether source exist in event log.
         If False = EventLog.SourceExists(mySource) Then
            ' Create a new source in a specified log on a system.
            EventLog.CreateEventSource(mySource, myLog)
         End If
         ' Create an event log instance.
         myEventLog = New EventLog(myLog)
         ' Initialize source property of obtained instance.
         myEventLog.Source = mySource
         Select Case myIntLog
            Case 1
               ' Write an 'Error' entry in specified log of event log.
               myEventLog.WriteEntry(myMessage, EventLogEntryType.Error, myID)
            Case 2
               ' Write a 'Warning' entry in specified log of event log.
               myEventLog.WriteEntry(myMessage, EventLogEntryType.Warning, myID)
            Case 3
               ' Write an 'Information' entry in specified log of event log.
               myEventLog.WriteEntry(myMessage, EventLogEntryType.Information, myID)
            Case 4
               ' Write a 'FailureAudit' entry in specified log of event log.
               myEventLog.WriteEntry(myMessage, EventLogEntryType.FailureAudit, myID)
            Case 5
               ' Write a 'SuccessAudit' entry in specified log of event log.
               myEventLog.WriteEntry(myMessage, EventLogEntryType.SuccessAudit, myID)
            Case Else
               Console.WriteLine("Error: Failed to create an event in event log.")
         End Select
         Console.WriteLine("A new event in log '{0}' with ID '{1}' " + _
                  "is successfully written into event log.", myEventLog.Log, myID)
' </Snippet2>
      Catch e As Exception
         Console.WriteLine("Exception: {0}", e.Message)
      End Try
   End Sub 'Main
End Class 'MyEventLogEntryType
' </Snippet1>
