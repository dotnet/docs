' <Snippet1>
Option Explicit On 
Option Strict On

Imports System
Imports System.Diagnostics
Imports System.Threading


Class MySample

    ' This member is used to wait for events.
    Private Shared signal As AutoResetEvent


    Public Shared Sub Main()

        signal = New AutoResetEvent(False)
        Dim myNewLog As New EventLog("Application", ".", "testEventLogEvent")

        AddHandler myNewLog.EntryWritten, AddressOf MyOnEntryWritten
        myNewLog.EnableRaisingEvents = True
        myNewLog.WriteEntry("Test message", EventLogEntryType.Information)

        signal.WaitOne()
    End Sub ' Main


    Public Shared Sub MyOnEntryWritten(ByVal [source] As Object, ByVal e As EntryWrittenEventArgs)
        Console.WriteLine("In event handler")
        signal.Set()
    End Sub ' MyOnEntryWritten
End Class ' MySample 

' </Snippet1>