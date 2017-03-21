void allItems_Click(Object sender,EventArgs e)
{
    IEnumerator dataListEnumerator;
    DataListItem currentItem;
    lblAllItems.Text = "";
    // Get an enumerator to traverse the DataListItemCollection.
    dataListEnumerator = myDataList.Items.GetEnumerator();
    while(dataListEnumerator.MoveNext())
    {
        currentItem = (DataListItem)dataListEnumerator.Current;
        // Display the current DataListItem onto the label.
        lblAllItems.Text += ((Label)(currentItem.Controls[1])).Text + " ";
    }
}