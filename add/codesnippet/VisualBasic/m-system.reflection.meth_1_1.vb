' Define a class with a generic method.
Public Class Example
    Public Shared Sub Generic(Of T)(ByVal toDisplay As T)
        Console.WriteLine(vbCrLf & "Here it is: {0}", toDisplay)
    End Sub
End Class