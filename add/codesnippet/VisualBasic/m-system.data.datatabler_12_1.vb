Private Sub PrintColumns( _
   ByVal reader As DataTableReader)

   ' Loop through all the rows in the DataTableReader.
   While reader.Read()
       For i As Integer = 0 To reader.FieldCount - 1
         Console.Write("{0} ", reader(i))
      Next
      Console.WriteLine()
   End While
End Sub