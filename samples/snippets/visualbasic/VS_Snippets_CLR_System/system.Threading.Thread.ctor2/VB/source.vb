' <Snippet1>
Imports System
Imports System.Threading

Public Class Test
    <MTAThread> _
    Shared Sub Main() 
        Dim threadWork As New Work()
        Dim newThread As New Thread(AddressOf threadWork.DoWork)
        newThread.Start()
    End Sub
End Class

Public Class Work

    Sub New()
    End Sub

    Sub DoWork() 
    End Sub

End Class
' </Snippet1>