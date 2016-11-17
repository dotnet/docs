        If e.DataRepeaterItem.Controls(RegionTextBox.Name).Text = "" Then
            e.DataRepeaterItem.Controls("RegionLabel").
             ForeColor = Color.Red
        Else
            e.DataRepeaterItem.Controls("RegionLabel").
             ForeColor = Color.Black
        End If