        ' Alternate the back color.
        If (e.DataRepeaterItem.ItemIndex Mod 2) <> 0 Then
            ' Apply the secondary back color.
            e.DataRepeaterItem.BackColor = Color.AliceBlue
        Else
            ' Apply the default back color.
            e.DataRepeaterItem.BackColor = DataRepeater1.BackColor
        End If