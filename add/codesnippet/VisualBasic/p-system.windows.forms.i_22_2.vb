    Dim price As Double = 0.0

    ' Handles the ItemChecked event. The method uses the CurrentValue property 
    ' of the ItemCheckEventArgs to retrieve and tally the price of the menu 
    ' items selected.  
    Private Sub ListView1_ItemCheck1(ByVal sender As Object, _
        ByVal e As System.Windows.Forms.ItemCheckEventArgs) _
        Handles ListView1.ItemCheck

        If (e.CurrentValue = CheckState.Unchecked) Then
            price += Double.Parse( _
            Me.ListView1.Items(e.Index).SubItems(1).Text)
        ElseIf (e.CurrentValue = CheckState.Checked) Then
            price -= Double.Parse( _
                Me.ListView1.Items(e.Index).SubItems(1).Text)
        End If

        ' Output the price to TextBox1.
        TextBox1.Text = CType(price, String)

    End Sub