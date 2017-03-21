 Sub R1_ItemCommand(Sender As Object, e As RepeaterCommandEventArgs)
     Label2.Text = "The index of the item is " & e.Item.ItemIndex.ToString()
 End Sub
