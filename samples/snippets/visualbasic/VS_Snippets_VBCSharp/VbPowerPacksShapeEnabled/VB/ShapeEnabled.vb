Public Class ShapeEnabled
    ' <Snippet1>
    Private Sub TextBox1_TextChanged() Handles TextBox1.TextChanged
        ' If the TextBox contains text, enable the RectangleShape.
        If TextBox1.Text <> "" Then
            ' Enable the RectangleShape.
            RectangleShape1.Enabled = True
            ' Change the BorderColor to the default.
            RectangleShape1.BorderColor = 
                Microsoft.VisualBasic.PowerPacks.Shape.DefaultBorderColor
        Else
            ' Disable the RectangleShape control.
            RectangleShape1.Enabled = False
            ' Change the BorderColor to show that the control is disabled
            RectangleShape1.BorderColor = 
                Color.FromKnownColor(KnownColor.InactiveBorder)
        End If
    End Sub
    ' </Snippet1>
End Class
