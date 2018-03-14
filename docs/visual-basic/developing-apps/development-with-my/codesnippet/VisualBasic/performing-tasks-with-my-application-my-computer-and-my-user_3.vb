        Dim reader = 
          My.Computer.FileSystem.OpenTextFieldParser("C:\TestFolder1\test1.txt")
        reader.TextFieldType = Microsoft.VisualBasic.FileIO.FieldType.Delimited
        reader.Delimiters = New String() {","}
        Dim currentRow As String()
        While Not reader.EndOfData
          Try
              currentRow = reader.ReadFields()
              Dim currentField As String
                For Each currentField In currentRow
                    MsgBox(currentField)
                Next
                Catch ex As Microsoft.VisualBasic.FileIO.MalformedLineException
                  MsgBox("Line " & ex.Message & 
                  "is not valid and will be skipped.")
            End Try
        End While