   Protected Sub AddTableStyle()
      ' Create a new DataGridTableStyle.
      myDataGridTableStyle = New DataGridTableStyle()
      myDataGridTableStyle.MappingName = myDataSet1.Tables(0).TableName
      myDataGrid1.DataSource = myDataSet1.Tables(0)
      AddHandler myDataGridTableStyle.ReadOnlyChanged, AddressOf MyReadOnlyChangedEventHandler
      myDataGrid1.TableStyles.Add(myDataGridTableStyle)
   End Sub 'AddTableStyle
   
   ' Handle the 'ReadOnlyChanged' event.
   Private Sub MyReadOnlyChangedEventHandler(sender As Object, e As EventArgs)
      MessageBox.Show("ReadOnly property is changed")
   End Sub 'MyReadOnlyChangedEventHandler

   ' Handle the check box's CheckedChanged event
   Private Sub myCheckBox1_CheckedChanged(sender As Object, e As EventArgs)
      If myDataGridTableStyle.ReadOnly Then
         myDataGridTableStyle.ReadOnly = False
      Else
         myDataGridTableStyle.ReadOnly = True
      End If
   End Sub 'myCheckBox1_CheckedChanged