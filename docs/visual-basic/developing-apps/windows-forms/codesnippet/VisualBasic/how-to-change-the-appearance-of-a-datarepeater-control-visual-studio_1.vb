        ' Set the default BackColor.
        e.DataRepeaterItem.BackColor = Color.White
        ' Loop through the controls on the DataRepeaterItem.
        For Each c As Control In e.DataRepeaterItem.Controls
            ' Check the type of each control.
            If TypeOf c Is TextBox Then
                ' If a TextBox, change the BackColor.
                c.BackColor = Color.AliceBlue
            Else
                ' Otherwise use the default BackColor.
                c.BackColor = e.DataRepeaterItem.BackColor
            End If
        Next