Public Class DataRepeaterSearch

    Private Sub ProductsBindingNavigatorSaveItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ProductsBindingNavigatorSaveItem.Click
        Me.Validate()
        Me.ProductsBindingSource.EndEdit()
        Me.TableAdapterManager.UpdateAll(Me.NorthwndDataSet)

    End Sub

    Private Sub DataRepeaterSearch_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        'TODO: This line of code loads data into the 'NorthwndDataSet.Products' table. You can move, or remove it, as needed.
        Me.ProductsTableAdapter.Fill(Me.NorthwndDataSet.Products)

    End Sub
    ' <Snippet1>
    Private Sub SearchButton_Click() Handles SearchButton.Click
        Dim foundIndex As Integer
        Dim searchString As String
        searchString = SearchTextBox.Text
        foundIndex = ProductsBindingSource.Find("ProductID", 
           searchString)
        If foundIndex > -1 Then
            DataRepeater1.CurrentItemIndex = foundIndex
        Else
            MsgBox("Item " & searchString & " not found.")
        End If
    End Sub
    ' </Snippet1>
End Class
