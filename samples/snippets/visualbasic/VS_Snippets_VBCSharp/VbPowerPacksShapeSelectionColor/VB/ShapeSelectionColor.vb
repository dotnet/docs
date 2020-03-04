Public Class ShapeSelectionColor
    ' <Snippet1>
    Private Sub RectangleShape1_GotFocus() Handles RectangleShape1.GotFocus
        ' If SelectionColor is the same as the form's BackColor.
        If RectangleShape1.SelectionColor = Me.BackColor Then
            ' Change the SelectionColor.
            RectangleShape1.SelectionColor = Color.Red
        Else
            ' Use the default SelectionColor.
            RectangleShape1.SelectionColor = SystemColors.Highlight
        End If
    End Sub
    ' </Snippet1>
End Class
