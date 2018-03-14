Public Class ShapeCollectionItem
    ' <Snippet1>
    Private Sub Button1_Click() Handles Button1.Click
        ' Set the focus to the first shape (index 0).
        ShapeContainer1.Shapes.Item(0).Focus()
    End Sub
    ' </Snippet1>
End Class
