    Private Sub DataRepeater1_DrawItem(
        ByVal sender As Object, 
        ByVal e As Microsoft.VisualBasic.PowerPacks.DataRepeaterItemEventArgs
      ) Handles DataRepeater1.DrawItem

        ' Alternate the back color.
        If (e.DataRepeaterItem.ItemIndex Mod 2) <> 0 Then
            ' Apply the secondary back color.
            e.DataRepeaterItem.BackColor = Color.AliceBlue
        Else
            ' Apply the default back color.
            e.DataRepeaterItem.BackColor = Color.White
        End If
        ' Change the color of out-of-stock items to red.
        If e.DataRepeaterItem.Controls(
              UnitsInStockTextBox.Name).Text < 1 Then

            e.DataRepeaterItem.Controls(UnitsInStockTextBox.Name). 
             BackColor = Color.Red
        Else
            e.DataRepeaterItem.Controls(UnitsInStockTextBox.Name). 
             BackColor = Color.White
        End If
    End Sub