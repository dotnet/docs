   private Sub GetGridTableByName()
      Dim myGridStyle As DataGridTableStyle = _
      myDataGrid.TableStyles("customers")
      Console.WriteLine(myGridStyle.MappingName)
   End Sub