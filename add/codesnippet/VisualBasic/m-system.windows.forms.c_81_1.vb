    Private Sub dataGrid1_KeyUp(ByVal sender As Object, _
    ByVal e As System.Windows.Forms.KeyEventArgs)

        If e.KeyCode = System.Windows.Forms.Keys.Escape Then
            ' Escape key pressed.
            Dim gridCurrencyManager As CurrencyManager = _
                CType(Me.BindingContext(dataGrid1.DataSource, _
                dataGrid1.DataMember), CurrencyManager)

            gridCurrencyManager.CancelCurrentEdit()
            MessageBox.Show("Escape!")
        End If
    End Sub 'dataGrid1_KeyUp