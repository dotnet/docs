        On Error Resume Next
        Dim myError As System.Exception
        ' Generate an overflow exception.
        Err.Raise(6)
        ' Assigns the exception from the Err object to myError.
        myError = Err.GetException()
        ' Displays the message associated with the exception.
        MsgBox(myError.Message)