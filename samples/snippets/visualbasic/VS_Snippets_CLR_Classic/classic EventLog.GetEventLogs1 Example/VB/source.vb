' <Snippet1>
Imports System.Diagnostics
Imports System.Threading

Class MySample
    Public Shared Sub Main()
        Dim remoteEventLogs() As EventLog
        
        remoteEventLogs = EventLog.GetEventLogs("myServer")
        
        Console.WriteLine(("Number of logs on computer: " & remoteEventLogs.Length))
        
        Dim log As EventLog
        For Each log In  remoteEventLogs
            Console.WriteLine(("Log: " & log.Log))
        Next log
    End Sub
End Class
' </Snippet1>