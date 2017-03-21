            ' Report that the required argument is not present.
            Const ENTER_PARAM As String = "Enter the number of " & _
                "possibilities as a command line argument."
            defaultListener.Fail(ENTER_PARAM)
            If Not defaultListener.AssertUiEnabled Then
                Console.WriteLine(ENTER_PARAM)
            End If