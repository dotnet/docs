    Private Sub ShowText(ByVal textFilePath As String)
        If System.IO.File.Exists(textFilePath) = False Then
            Debug.WriteLine("File Not Found: " & textFilePath)
        Else
            Dim sr As System.IO.StreamReader = System.IO.File.OpenText(textFilePath)

            Do While sr.Peek() >= 0
                Debug.WriteLine(sr.ReadLine())
            Loop

            sr.Close()
        End If
    End Sub