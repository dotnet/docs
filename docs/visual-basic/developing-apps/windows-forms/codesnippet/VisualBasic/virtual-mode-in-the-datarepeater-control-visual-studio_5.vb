    Private Sub DataRepeater1_ItemsRemoved(
        ByVal sender As Object, 
        ByVal e As Microsoft.VisualBasic.PowerPacks.DataRepeaterAddRemoveItemsEventArgs
      ) Handles DataRepeater1.ItemsRemoved

        Employees.RemoveAt(e.ItemIndex)
    End Sub