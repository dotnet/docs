    Sub tenv()
        Dim envString As String
        Dim found As Boolean = False
        Dim index As Integer = 1
        Dim pathLength As Integer
        Dim message As String

        envString = Environ(index)
        While Not found And (envString <> "")
            If (envString.Substring(0, 5) = "Path=") Then
                found = True
            Else
                index += 1
                envString = Environ(index)
            End If
        End While

        If found Then
            pathLength = Environ("PATH").Length
            message = "PATH entry = " & index & " and length = " & pathLength
        Else
            message = "No PATH environment variable exists."
        End If

        MsgBox(message)
    End Sub