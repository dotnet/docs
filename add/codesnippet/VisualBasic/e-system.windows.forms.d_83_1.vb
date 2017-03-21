   Private Sub AddCustomColumnStyle()
      Dim myTableStyle As New DataGridTableStyle()
      myTableStyle.MappingName = "Orders"
      myColumnStyle = New DataGridTextBoxColumn()
      myColumnStyle.MappingName = "Orders"
      myColumnStyle.HeaderText = "Orders"
      myTableStyle.GridColumnStyles.Add(myColumnStyle)
      myDataGrid.TableStyles.Add(myTableStyle)
      AddHandler myColumnStyle.MappingNameChanged, AddressOf columnStyle_MappingNameChanged
      flag = True
   End Sub 'AddCustomColumnStyle

   ' MappingNameChanged event handler of DataGridColumnStyle.
   Private Sub columnStyle_MappingNameChanged(ByVal sender As Object, ByVal e As EventArgs)
      MessageBox.Show("Mapping Name changed")
   End Sub 'columnStyle_MappingNameChanged