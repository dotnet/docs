10:     On Error Resume Next
20:     Err.Raise(60000)
' Returns 20.
30:     MsgBox(Erl())