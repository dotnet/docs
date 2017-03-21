    On Error Resume Next
    Err.Raise(60000)
    Err.Description = "Your Widget needs a new Frob!"
    MsgBox(Err.Description)