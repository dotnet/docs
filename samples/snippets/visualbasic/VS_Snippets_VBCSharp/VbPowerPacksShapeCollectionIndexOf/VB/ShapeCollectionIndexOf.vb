Public Class ShapeCollectionIndexOf
    ' <Snippet1>
    Private Sub OvalShape2_Click() Handles OvalShape2.Click
        Dim i As Integer
        ' Find the index for OvalShape1.
        i = OvalShape2.Parent.Shapes.IndexOf(OvalShape1)
        ' If the shape is not in the collection, display a message.
        If i = -1 Then
            MsgBox("OvalShape1 is not in this collection.")
        End If
    End Sub
    ' </Snippet1>
    ' <Snippet2>
    Private Sub OvalShape1_Click() Handles OvalShape1.Click
        Dim i As Integer
        ' Find the index for OvalShape1.
        i = OvalShape1.Parent.Shapes.IndexOfKey("OvalShape2")
        ' If the shape is not in the collection, display a message.
        If i = -1 Then
            MsgBox("OvalShape2 is not in this collection.")
        End If
    End Sub
    ' </Snippet2>
End Class
