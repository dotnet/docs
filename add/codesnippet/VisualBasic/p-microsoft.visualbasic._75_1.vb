        Using MyReader As New Microsoft.VisualBasic.FileIO.
            TextFieldParser("C:\ParserText.txt")

            MyReader.TextFieldType = 
                Microsoft.VisualBasic.FileIO.FieldType.FixedWidth
            MyReader.FieldWidths = {5, 10, 11, -1}
            Dim currentRow As String()
            While Not MyReader.EndOfData
                Try
                    currentRow = MyReader.ReadFields()
                    Dim currentField As String
                    For Each currentField In currentRow
                        MsgBox(currentField)
                    Next
                Catch ex As Microsoft.VisualBasic.FileIO.MalformedLineException
                    MsgBox("Line " & ex.Message & 
                    "is not valid and will be skipped.")
                End Try
            End While
        End Using