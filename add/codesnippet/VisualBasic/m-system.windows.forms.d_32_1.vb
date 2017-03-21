   Private Sub AddGridTable()
      Dim myGridTableStyle As DataGridTableStyle
      myGridTableStyle = New DataGridTableStyle()
      myGridTableStyle.MappingName = "Customers"
      dataGrid1.TableStyles.Add(myGridTableStyle)
   End Sub 