Public Class DataError

    Private Sub ProductsBindingNavigatorSaveItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ProductsBindingNavigatorSaveItem.Click
        Me.Validate()
        Me.ProductsBindingSource.EndEdit()
        Me.TableAdapterManager.UpdateAll(Me.NorthwndDataSet)

    End Sub

    Private Sub DataError_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        'TODO: This line of code loads data into the 'NorthwndDataSet.Products' table. You can move, or remove it, as needed.
        Me.ProductsTableAdapter.Fill(Me.NorthwndDataSet.Products)

    End Sub
    ' <Snippet1>
    Private Sub DataRepeater1_DataError(
        ByVal sender As Object, 
        ByVal e As Microsoft.VisualBasic.PowerPacks.DataRepeaterDataErrorEventArgs
      ) Handles DataRepeater1.DataError

        Dim ErrorMsg As String
        ' Create an error string.
        ErrorMsg = "Invalid value entered for " & e.Control.Name & ". "
        ErrorMsg = ErrorMsg & e.Exception.Message
        ' Display the error to the user.
        MsgBox(ErrorMsg)
        ' Do not raise an exception.
        e.ThrowException = False
    End Sub
    ' </Snippet1>
End Class
