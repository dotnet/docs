        Using MyReader As New Microsoft.VisualBasic.FileIO.TextFieldParser("C:\ParserText.txt")
            MyReader.TextFieldType = Microsoft.VisualBasic.FileIO.FieldType.Delimited
            MyReader.Delimiters = New String() {","}
            Dim currentRow As String
            While Not MyReader.EndOfData
                Try
                    currentRow = MyReader.ReadLine()
                    My.Computer.FileSystem.WriteAllText(
                       "C://testfile.txt", currentRow, True)
                Catch ex As Microsoft.VisualBasic.FileIO.MalformedLineException
                    MsgBox("Line " & ex.Message & " is invalid.  Skipping")
                End Try
            End While
        End Using