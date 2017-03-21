   Private Sub RegisterEventHandlers(myDataGridBoolColumn As DataGridBoolColumn)
      AddHandler myDataGridBoolColumn.AllowNullChanged, _
                          AddressOf myDataGridBoolColumn_AllowNullChanged
      AddHandler myDataGridBoolColumn.TrueValueChanged, _
                          AddressOf myDataGridBoolColumn_TrueValueChanged
      AddHandler myDataGridBoolColumn.FalseValueChanged, _
                          AddressOf myDataGridBoolColumn_FalseValueChanged
   End Sub 'RegisterEventHandlers
   
   
   ' Event handler for event when 'TrueValue' is property changed.
   Private Sub myDataGridBoolColumn_TrueValueChanged(sender As Object, e As EventArgs)
      MessageBox.Show("The TrueValue property of the DataGridBoolColumn has been changed to " _
                                                    & myDataGridBoolColumn.TrueValue)
   End Sub 'myDataGridBoolColumn_TrueValueChanged
   
   
   ' Event handler for event when 'FalseValue' is property changed.
   Private Sub myDataGridBoolColumn_FalseValueChanged(sender As Object, e As EventArgs)
      MessageBox.Show("The FalseValue property of the DataGridBoolColumn has been changed to " _
                                                        & myDataGridBoolColumn.FalseValue)
   End Sub 'myDataGridBoolColumn_FalseValueChanged
   
   
   ' Event handler for event when 'AllowNull' is property changed.
   Private Sub myDataGridBoolColumn_AllowNullChanged(sender As Object, e As EventArgs)
      MessageBox.Show("The AllowNull property of DataGridBoolColumn has been changed to " _
                                                          & myDataGridBoolColumn.AllowNull)
   End Sub 'myDataGridBoolColumn_AllowNullChanged
   
   