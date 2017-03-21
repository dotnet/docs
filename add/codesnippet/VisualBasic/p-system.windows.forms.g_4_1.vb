   Private Sub GetGridTableByIndex()
      Dim myGridStyle As DataGridTableStyle = _
      myDataGrid.TableStyles(0)
      Console.WriteLine(myGridStyle.MappingName)
   End Sub