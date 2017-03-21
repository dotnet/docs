   Private Sub AddCustomColumnStyle()
      myTableStyle = New DataGridTableStyle()
      myColumnStyle = New DataGridTextBoxColumn()
      AddHandler myColumnStyle.NullTextChanged, AddressOf columnStyle_NullTextChanged
      myTableStyle.GridColumnStyles.Add(myColumnStyle)
      myDataGrid.TableStyles.Add(myTableStyle)
   End Sub 'AddCustomColumnStyle

   ' NullTextChanged event handler of DataGridColumnStyle.
   Private Sub columnStyle_NullTextChanged(ByVal sender As Object, ByVal e As EventArgs)
      Dim i As Integer
      For i = 0 To myRowcount - 1
         myCell.RowNumber = i
         myDataGrid(myCell) = Nothing
      Next i
      MessageBox.Show("NullTextChanged Event is handled")
   End Sub 'columnStyle_NullTextChanged