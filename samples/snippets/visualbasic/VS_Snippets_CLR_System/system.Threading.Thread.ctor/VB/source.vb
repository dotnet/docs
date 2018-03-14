' <Snippet1>
Imports System
Imports System.Threading

Public Class Test
    <MTAThread> _
    Shared Sub Main()
        Dim newThread As New Thread(AddressOf Work.DoWork)
        newThread.Start()
    End Sub
End Class

Public Class Work 

    Private Sub New()
    End Sub

    Shared Sub DoWork()
    End Sub

End Class
' </Snippet1>