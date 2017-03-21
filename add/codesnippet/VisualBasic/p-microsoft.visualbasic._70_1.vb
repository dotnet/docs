    Dim Msg As String
    Err.Clear()
    On Error Resume Next   ' Suppress errors for demonstration purposes.
    Err.Raise(6)   ' Generate "Overflow" error.
    If Err.Number <> 0 Then
      Msg = "Press F1 or HELP to see " & Err.HelpFile & " topic for" & 
      " the following HelpContext: " & Err.HelpContext
      MsgBox(Msg, , "Error:")
    End If