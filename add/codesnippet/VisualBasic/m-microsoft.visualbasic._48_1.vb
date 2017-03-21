        Using MyReader As New Microsoft.VisualBasic.FileIO.TextFieldParser("C:\ParserText.txt")
            MyReader.TextFieldType = Microsoft.VisualBasic.FileIO.FieldType.Delimited
            MyReader.Delimiters = New String() {","}
            MyReader.CommentTokens = New String() {"'"}
            Dim currentRow As String()
            While (MyReader.PeekChars(1) IsNot "")
                Try
                    currentRow = MyReader.ReadFields()
                    For Each currentField As String In currentRow
                        My.Computer.FileSystem.WriteAllText(
                           "C://testfile.txt", currentField, True)
                    Next
                Catch ex As Microsoft.VisualBasic.FileIO.MalformedLineException
                    MsgBox("Line " & ex.Message & " is invalid.  Skipping")
                End Try
            End While
        End Using