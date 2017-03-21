Private Sub TestGetFieldType(ByVal reader As DataTableReader)
   For i As Integer = 0 To reader.FieldCount - 1
      Console.WriteLine(reader.GetName(i) & ":" & _
         reader.GetFieldType(i).FullName)
   Next
   Console.WriteLine("Press Enter to finish.")
   Console.ReadLine()
End Sub