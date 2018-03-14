
Dim currentRow As String()
   While Not MyReader.EndOfData
      Try
         currentRow = MyReader.ReadFields()
         Dim currentField As String
         For Each currentField In currentRow
            MsgBox(currentField)
         Next
         Catch ex As Microsoft.VisualBasic.
                     FileIO.MalformedLineException
           MsgBox("Line " & ex.Message &
           "is not valid and will be skipped.")
     End Try