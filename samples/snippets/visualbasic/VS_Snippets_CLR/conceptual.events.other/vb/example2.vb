'<snippet20>
Public Class MouseEventArgs
    Inherits EventArgs
End Class

Public Class EventNameEventArgs
    Inherits EventArgs
End Class

Class EventingSnippets
    '<snippet21>
    Public Event EventName As EventNameEventHandler
    '</snippet21>

    '<snippet22>
    Public Delegate Sub EventNameEventHandler(sender As Object, e As EventNameEventArgs)
    '</snippet22>

    '<snippet23>
    Sub EventHandler(sender As Object, e As EventNameEventArgs)
    End Sub
    '</snippet23>

    '<snippet24>
    Sub Mouse_Moved(sender As Object, e As MouseEventArgs)
    End Sub
    '</snippet24>

    Sub OnSomeSignal(e As EventNameEventArgs)
        RaiseEvent EventName(Me, e)
    End Sub

    Public Shared Sub Main()
        Console.WriteLine("EventingSnippets Main()")
    End Sub
End Class
'</snippet20>
