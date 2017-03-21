 Private Sub ClearTable(table As DataTable)
     Try
         table.Clear()
     Catch e As DataException
	 ' Process exception and return.
          Console.WriteLine("Exception of type {0} occurred.", _
            e.GetType().ToString())
     End Try
 End Sub