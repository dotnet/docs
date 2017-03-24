Using Reader As New Microsoft.VisualBasic.FileIO.
   TextFieldParser("C:\TestFolder\test.log")

   Reader.TextFieldType =
      Microsoft.VisualBasic.FileIO.FieldType.FixedWidth
   Reader.SetFieldWidths(5, 10, 11, -1)
   Dim currentRow As String()
   While Not Reader.EndOfData
      Try
         currentRow = Reader.ReadFields()
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