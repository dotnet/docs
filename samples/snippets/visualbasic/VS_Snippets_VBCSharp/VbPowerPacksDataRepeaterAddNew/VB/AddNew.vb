Public Class Form1

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles AddNewButton.Click

    End Sub

    Private Sub ProductsBindingNavigatorSaveItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ProductsBindingNavigatorSaveItem.Click
        Me.Validate()
        Me.ProductsBindingSource.EndEdit()
        Me.TableAdapterManager.UpdateAll(Me.NorthwndDataSet)

    End Sub

    Private Sub Form1_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        'TODO: This line of code loads data into the 'NorthwndDataSet.Products' table. You can move, or remove it, as needed.
        Me.ProductsTableAdapter.Fill(Me.NorthwndDataSet.Products)

    End Sub
    ' <Snippet1>
    Private Sub AddNewButton_Click() Handles AddNewButton.Click
        ' Add a new repeater item.
        DataRepeater1.AddNew()
        ' Set the default text.
        DataRepeater1.CurrentItem.Controls("ProductNameTextBox").Text = 
           "New Product"
    End Sub
    ' </Snippet1>

End Class
