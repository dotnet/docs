    Public Sub ShowMyDialogBox()
        Dim testDialog As New Form2()
        
        ' Show testDialog as a modal dialog and determine if DialogResult = OK.
        If testDialog.ShowDialog(Me) = System.Windows.Forms.DialogResult.OK Then
            ' Read the contents of testDialog's TextBox.
            txtResult.Text = testDialog.TextBox1.Text
        Else
            txtResult.Text = "Cancelled"
        End If
        testDialog.Dispose()
    End Sub 'ShowMyDialogBox