  Sub ClearErr()
    ' Produce overflow error
    On Error Resume Next
    Dim zero As Integer = 0
    Dim result As Integer = 8 / zero
    MsgBox(Err.Description)
    Err.Clear()
    MsgBox(Err.Description)
  End Sub