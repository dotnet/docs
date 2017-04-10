'<Snippet1>
Imports System
Imports System.ServiceProcess



Class Program
    
    Private Enum SimpleServiceCustomCommands
        StopWorker = 128
        RestartWorker
        CheckWorker '
    End Enum 'SimpleServiceCustomCommands

    Shared Sub Main(ByVal args() As String) 
        Dim myService As New ServiceController("SimpleService")
        myService.ExecuteCommand(Fix(SimpleServiceCustomCommands.StopWorker))
        myService.ExecuteCommand(Fix(SimpleServiceCustomCommands.RestartWorker))
        myService.ExecuteCommand(Fix(SimpleServiceCustomCommands.CheckWorker))
    
    End Sub 'Main 
End Class 'Program 
'</Snippet1>