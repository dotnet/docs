        Private Sub Button_Click(ByVal sender As Object, ByVal e As EventArgs)
            If myButton.Text = "Make column read/write" Then
                myDataGridColumnStyle.ReadOnly = False
                myButton.Text = "Make column read only"
            Else
                myDataGridColumnStyle.ReadOnly = True
                myButton.Text = "Make column read/write"
            End If
        End Sub 'Button_Click

      Private Sub AddCustomDataTableStyle()
         myDataGridTableStyle = New DataGridTableStyle()
         myDataGridTableStyle.MappingName = "Customers"
         myDataGridColumnStyle = New DataGridTextBoxColumn()
         myDataGridColumnStyle.MappingName = "CustName"
         ' Add EventHandler function for readonlychanged event.
         AddHandler myDataGridColumnStyle.ReadOnlyChanged, AddressOf myDataGridColumnStyle_ReadOnlyChanged
         myDataGridColumnStyle.HeaderText = "Customer"
         myDataGridTableStyle.GridColumnStyles.Add(myDataGridColumnStyle)
         ' Add the 'DataGridTableStyle' instance to the 'DataGrid'.
         myDataGrid.TableStyles.Add(myDataGridTableStyle)
      End Sub 'AddCustomDataTableStyle

        Private Sub myDataGridColumnStyle_ReadOnlyChanged(ByVal sender As Object, ByVal e As EventArgs)
            MessageBox.Show("'Readonly' property is changed")
        End Sub 'myDataGridColumnStyle_ReadOnlyChanged