void R1_ItemCommand(Object Sender, RepeaterCommandEventArgs e) {        
    Label2.Text = "The index of the item is " + e.Item.ItemIndex.ToString();
 }
    