' System.Diagnostics.EventLog.WriteEntry(String,EventLogEntryType,Int32,Int16,Byte[])

' The following sample demonstrates the 
' 'WriteEntry(String, EventLogEntryType, Int32, Int16, Byte[])' method of 
' 'EventLog' class. It writes an entry to a custom event log, "MyLog".
' It creates the source "MySource" if the source does not already exist.
' It creates an 'EventLog' object and calls 'WriteEntry' passing the 
' description, Log entry type, application specific identifier for the event,
' application specific subcategory and  data to be associated with the entry.

Imports System
Imports System.Diagnostics

Class EventLog_WriteEntry_5
   
   Public Shared Sub Main()
      Try
' <Snippet1>
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
' </Snippet1>        
      Catch e As Exception
         Console.WriteLine("Exception:{0}", e.Message.ToString())
      End Try
   End Sub 'Main
End Class 'EventLog_WriteEntry_5

