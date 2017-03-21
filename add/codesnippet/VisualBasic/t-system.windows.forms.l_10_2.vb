    ' Uses the SelectedItems property to retrieve and tally the price 
    ' of the selected menu items.
    Private Sub ListView1_SelectedIndexChanged_UsingItems _
        (ByVal sender As Object, ByVal e As System.EventArgs) _
        Handles ListView1.SelectedIndexChanged

        Dim breakfast As ListView.SelectedListViewItemCollection = _
            Me.ListView1.SelectedItems
        Dim item As ListViewItem
        Dim price As Double = 0.0
        For Each item In breakfast
            price += Double.Parse(item.SubItems(1).Text)
        Next

        ' Output the price to TextBox1.
        TextBox1.Text = CType(price, String)
    End Sub