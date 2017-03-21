  Public Class Class1
    Public Sub MySub()
        On Error Resume Next
        Err.Raise(60000, "Class1")
        MsgBox(Err.Source & " caused an error of type " & Err.Number)
    End Sub
  End Class