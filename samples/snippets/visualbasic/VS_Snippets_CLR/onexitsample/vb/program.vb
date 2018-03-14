'<Snippet1>
Imports System
Imports System.Diagnostics


Class MyProcess
    Inherits Process
    
    Public Sub [Stop]() 
        Me.CloseMainWindow()
        Me.Close()
        OnExited()
    
    End Sub 'Stop
End Class

Class StartNotePad
    
    
    Public Shared Sub Main(ByVal args() As String) 
        Dim p As New MyProcess()
        p.StartInfo.FileName = "notepad.exe"
        p.EnableRaisingEvents = True
        AddHandler p.Exited, AddressOf myProcess_HasExited
        p.Start()
        p.WaitForInputIdle()
        p.Stop()
    
    End Sub
    
    Private Shared Sub myProcess_HasExited(ByVal sender As Object, ByVal e As System.EventArgs) 
        Console.WriteLine("Process has exited.")
    
    End Sub 'myProcess_HasExited
End Class
'</Snippet1>