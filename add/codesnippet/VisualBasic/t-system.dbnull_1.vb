   Private Sub OUtputLabels(dt As DataTable)
      Dim label As String 

      ' Iterate rows of table
      For Each row As DataRow In dt.Rows
         Dim labelLen As Integer
         label = String.Empty
         label += AddFieldValue(label, row, "Title")
         label += AddFieldValue(label, row, "FirstName")
         label += AddFieldValue(label, row, "MiddleInitial")
         label += AddFieldValue(label, row, "LastName")
         label += AddFieldValue(label, row, "Suffix")
         label += vbCrLf
         label += AddFieldValue(label, row, "Address1")
         label += AddFieldValue(label, row, "AptNo")
         label += vbCrLf
         labelLen = Len(label)
         label += AddFieldValue(label, row, "Address2")
         If Len(label) <> labelLen Then label += vbCrLf
         label += AddFieldValue(label, row, "City")
         label += AddFieldValue(label, row, "State")
         label += AddFieldValue(label, row, "Zip")
         Console.WriteLine(label)
         Console.WriteLine()
      Next
   End Sub

   Private Function AddFieldValue(label As String, row As DataRow, _
                             fieldName As String) As String
      If Not DbNull.Value.Equals(row.Item(fieldName)) Then
         Return CStr(row.Item(fieldName)) & " "
      Else
         Return Nothing
      End If
   End Function