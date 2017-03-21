        Using MyReader As New Microsoft.VisualBasic.FileIO.
            TextFieldParser("c:\logs\bigfile")

            MyReader.TextFieldType = 
                Microsoft.VisualBasic.FileIO.FieldType.Delimited
            MyReader.Delimiters = New String() {vbTab}
            Dim currentRow As String()
            'Loop through all of the fields in the file. 
            'If any lines are corrupt, report an error and continue parsing. 
            While Not MyReader.EndOfData
                Try
                    currentRow = MyReader.ReadFields()
                    ' Include code here to handle the row.
                Catch ex As Microsoft.VisualBasic.FileIO.MalformedLineException
                    MsgBox("Line " & ex.Message & 
                    " is invalid.  Skipping")
                End Try
            End While
        End Using