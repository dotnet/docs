    Private Sub DataRepeater1_ItemCloned(
        ByVal sender As Object, 
        ByVal e As Microsoft.VisualBasic.PowerPacks.DataRepeaterItemEventArgs
      ) Handles DataRepeater1.ItemCloned

        Dim Source As ListBox = 
            CType(DataRepeater1.ItemTemplate.Controls.Item("ListBox1"), ListBox)
        Dim ListBox1 As ListBox = 
            CType(e.DataRepeaterItem.Controls.Item("ListBox1"), ListBox)
        For Each s As String In Source.Items
            ListBox1.Items.Add(s)
        Next
    End Sub