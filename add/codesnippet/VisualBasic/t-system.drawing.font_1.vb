    Private Sub ComboBox1_SelectedIndexChanged(ByVal sender As System.Object, _
        ByVal e As System.EventArgs) Handles ComboBox1.SelectedIndexChanged

        ' Cast the sender object back to a ComboBox.
        Dim ComboBox1 As ComboBox = CType(sender, ComboBox)

        ' Retrieve the selected item.
        Dim selectedString As String = CType(ComboBox1.SelectedItem, String)

        ' Convert it to lowercase.
        selectedString = selectedString.ToLower()

        ' Declare the current size.
        Dim currentSize As Single

        ' Switch on the selected item. 
        Select Case selectedString

            ' If Bigger is selected, get the current size from the 
            ' Size property and increase it. Reset the font to the
            '  new size, using the current unit.
        Case "bigger"
                currentSize = Label1.Font.Size
                currentSize += 2.0F
                Label1.Font = New Font(Label1.Font.Name, currentSize, _
                    Label1.Font.Style, Label1.Font.Unit)

                ' If Smaller is selected, get the current size, in points,
                ' and decrease it by 1.  Reset the font with the new size
                ' in points.
            Case "smaller"
                currentSize = Label1.Font.SizeInPoints
                currentSize -= 1
                Label1.Font = New Font(Label1.Font.Name, currentSize, _
                    Label1.Font.Style)
        End Select
    End Sub