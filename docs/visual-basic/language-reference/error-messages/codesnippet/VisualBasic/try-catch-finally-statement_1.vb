    Private Sub TextFileExample(ByVal filePath As String)

        ' Verify that the file exists.
        If System.IO.File.Exists(filePath) = False Then
            Console.Write("File Not Found: " & filePath)
        Else
            ' Open the text file and display its contents.
            Dim sr As System.IO.StreamReader =
                System.IO.File.OpenText(filePath)

            Console.Write(sr.ReadToEnd)

            sr.Close()
        End If
    End Sub