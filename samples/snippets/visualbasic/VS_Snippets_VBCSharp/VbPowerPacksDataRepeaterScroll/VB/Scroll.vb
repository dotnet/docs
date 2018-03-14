Public Class Scroll

    Private Sub CategoriesBindingNavigatorSaveItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CategoriesBindingNavigatorSaveItem.Click
        Me.Validate()
        Me.CategoriesBindingSource.EndEdit()
        Me.TableAdapterManager.UpdateAll(Me.NorthwndDataSet)

    End Sub

    Private Sub Scroll_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        'TODO: This line of code loads data into the 'NorthwndDataSet.Categories' table. You can move, or remove it, as needed.
        Me.CategoriesTableAdapter.Fill(Me.NorthwndDataSet.Categories)

    End Sub
    ' <Snippet1>
    Private Sub SynchButton_Click() Handles SynchButton.Click
        ' If the first displayed item is not the current item.
        If DataRepeater1.FirstDisplayedItemIndex <> 
          DataRepeater1.CurrentItemIndex Then
            ' Make it the current item.
            DataRepeater1.CurrentItemIndex = 
              DataRepeater1.FirstDisplayedItemIndex
            ' Align it with the top of the control.
            DataRepeater1.ScrollItemIntoView( 
              DataRepeater1.FirstDisplayedItemIndex, True)
        End If
    End Sub
    ' </Snippet1>
End Class
