    ' Uses the SelectedIndices property to retrieve and tally the price of  
    ' the selected menu items.
    Private Sub ListView1_SelectedIndexChanged_UsingIndices _
        (ByVal sender As Object, ByVal e As System.EventArgs) _
        Handles ListView1.SelectedIndexChanged

        Dim indexes As ListView.SelectedIndexCollection = _
            Me.ListView1.SelectedIndices
        Dim index As Integer
        Dim price As Double = 0.0
        For Each index In indexes
            price += Double.Parse(Me.ListView1.Items(index).SubItems(1).Text)
        Next

        ' Output the price to TextBox1.
        TextBox1.Text = CType(price, String)
    End Sub