Public Class HeaderVisibleChanged

    Private Sub CategoriesBindingNavigatorSaveItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CategoriesBindingNavigatorSaveItem.Click
        Me.Validate()
        Me.CategoriesBindingSource.EndEdit()
        Me.TableAdapterManager.UpdateAll(Me.NorthwndDataSet)

    End Sub

    Private Sub HeaderVisibleChanged_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        'TODO: This line of code loads data into the 'NorthwndDataSet.Categories' table. You can move, or remove it, as needed.
        Me.CategoriesTableAdapter.Fill(Me.NorthwndDataSet.Categories)

    End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        If DataRepeater1.ItemHeaderVisible = False Then
            DataRepeater1.ItemHeaderVisible = True
        Else
            DataRepeater1.ItemHeaderVisible = False
        End If
    End Sub
    ' <Snippet1>
    Private Sub DataRepeater1_ItemHeaderVisibleChanged(
        ) Handles DataRepeater1.ItemHeaderVisibleChanged

        ' Display the selection mode in the label.
        If DataRepeater1.ItemHeaderVisible = False Then
            SelectionModeLabel.Text = "Selected item marked by selection " & 
             "rectangle."
        Else
            SelectionModeLabel.Text = "Selected item marked by item " & 
             "header."
        End If
    End Sub
    ' </Snippet1>
End Class
