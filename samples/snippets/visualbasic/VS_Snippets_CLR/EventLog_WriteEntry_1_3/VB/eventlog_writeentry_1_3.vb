' System.Diagnostics.EventLog.WriteEntry(String, String, EventLogEntryType, Int32, Int16)
' System.Diagnostics.EventLog.WriteEntry(String, String, EventLogEntryType, Int32, Int16, Byte[])
' System.Diagnostics.EventLog.EventLog.WriteEntry(String, EventLogEntryType, Int32, Int16)

' The following example demonstrates the method 
' 'WriteEntry(String, String, EventLogEntryType, Int32, Int16)', 
' 'WriteEntry(String, String, EventLogEntryType, Int32, Int16, Byte[]) ' 
' and 'WriteEntry(String, EventLogEntryType, Int32, Int16)' of class 
' 'EventLog'.The following example writes the information to an event log. 


Imports System
Imports System.Diagnostics

Class MyEventLog

    Public Shared Sub Main()
        ' <Snippet1>
        Dim myEventID As Integer = 10
        Dim myCategory As Short = 20
        ' Write an informational entry to the event log.
        Console.WriteLine("Write from first source ")
        EventLog.WriteEntry("FirstSource", "Writing warning to event log.", _
                                   EventLogEntryType.Information, myEventID, myCategory)
        ' </Snippet1>

        ' <Snippet2>
        ' Create a byte array for binary data to associate with the entry.
        Dim myByte(9) As Byte
        Dim i As Integer
        ' Populate the byte array with simulated data.
        For i = 0 To 9
            myByte(i) = CByte(i Mod 2)
        Next i
        ' Write an entry to the event log that includes associated binary data.
        Console.WriteLine("Write from second source ")
        EventLog.WriteEntry("SecondSource", "Writing warning to event log.", _
                             EventLogEntryType.Error, myEventID, myCategory, myByte)
        ' </Snippet2>

        ' <Snippet3>
        ' Create an EventLog instance and assign its source.
        Dim myLog As New EventLog()
        myLog.Source = "ThirdSource"

        ' Write an informational entry to the event log.
        Console.WriteLine("Write from third source ")
        myLog.WriteEntry("Writing warning to event log.", EventLogEntryType.Warning, _
                             myEventID, myCategory)
        ' </Snippet3>
    End Sub 'Main
End Class 'MyEventLog    