Imports System
Imports System.Data
Imports System.Windows.Forms



Public Class Form1
   Inherits Form
   Protected textBox1 As TextBox
   Protected dataGrid1 As DataGrid
    
   ' <Snippet1>
    Private Sub dataGrid1_KeyUp _
   (ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs)
        If e.KeyCode = Keys.Enter Then
            ' Enter key pressed.
            Dim gridCurrencyManager As CurrencyManager = _
            CType(Me.BindingContext(dataGrid1.DataSource, _
            dataGrid1.DataMember), CurrencyManager)
            gridCurrencyManager.EndCurrentEdit()
            MessageBox.Show("End Edit")
        End If
    End Sub 'dataGrid1_KeyUp
    ' </Snippet1>
End Class 'Form1 
