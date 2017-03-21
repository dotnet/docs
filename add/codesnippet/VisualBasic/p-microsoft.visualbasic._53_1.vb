        Dim FileReader As Microsoft.VisualBasic.FileIO.TextFieldParser
        FileReader = My.Computer.FileSystem.OpenTextFieldParser("C:\test.txt")
        Dim currentRow As String()
        While Not FileReader.EndOfData
            Try
                currentRow = FileReader.ReadFields
                For Each currentField As String In currentRow
                    My.Computer.FileSystem.WriteAllText(
                        "C://testfile.txt", currentField, True)
                Next
            Catch ex As Microsoft.VisualBasic.FileIO.MalformedLineException
                MsgBox("Line " & FileReader.ErrorLine & " is not valid.")
            End Try
        End While