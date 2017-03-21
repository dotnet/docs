        Using FileReader As New Microsoft.VisualBasic.FileIO.TextFieldParser("C:\ParserText.txt")
            FileReader.TextFieldType = Microsoft.VisualBasic.FileIO.FieldType.Delimited
            FileReader.Delimiters = New String() {","}
            Dim currentRow As String()
            While Not FileReader.EndOfData
                Try
                    currentRow = FileReader.ReadFields()
                    Dim currentField As String
                    For Each currentField In currentRow
                        If currentField = "Jones" Then
                            MsgBox("The name Jones occurs on line " & 
                            FileReader.LineNumber)
                        End If
                    Next
                Catch ex As Microsoft.VisualBasic.FileIO.MalformedLineException
                    MsgBox("Line " & ex.Message & 
                   "is not valid and will be skipped.")
                End Try
            End While
        End Using