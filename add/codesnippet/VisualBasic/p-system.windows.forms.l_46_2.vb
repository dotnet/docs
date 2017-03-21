    ' Handles the ItemCheck event.  The method loops through all the 
    ' checked items and tallies a new price each time an item is 
    ' checked or unchecked. It outputs the price to TextBox1.
    Private Sub ListView1_ItemCheck2(ByVal sender As Object, _
        ByVal e As System.Windows.Forms.ItemCheckEventArgs) _
        Handles ListView1.ItemCheck

        Dim item As ListViewItem
        Dim price As Double = 0.0
        Dim checkedItems As ListView.CheckedListViewItemCollection = _
            ListView1.CheckedItems
        For Each item In checkedItems
            price += Double.Parse(item.SubItems(1).Text)
        Next
        If (e.CurrentValue = CheckState.Unchecked) Then
            price += Double.Parse(Me.ListView1.Items(e.Index).SubItems(1).Text)
        ElseIf (e.CurrentValue = CheckState.Checked) Then
            price -= Double.Parse(Me.ListView1.Items(e.Index).SubItems(1).Text)
        End If

        ' Output the price to TextBox1.
        TextBox1.Text = CType(price, String)
    End Sub