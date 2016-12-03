        ' Displays a message box that shows the full command line for the
        ' application.
        Dim args As String = ""
        For Each arg As String In My.Application.CommandLineArgs
            args &= arg & " "
        Next
        MsgBox(args)