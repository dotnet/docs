Public Class ShapeCollectionSetChildIndex
    ' <Snippet1>
    Private Sub OvalShape1_Click() Handles OvalShape1.Click
        Dim i As Integer
        ' Find the index for OvalShape2.
        i = OvalShape1.Parent.Shapes.GetChildIndex(OvalShape2, False)
        ' If the shape is not in the collection, display a message.
        If i = -1 Then
            MsgBox("OvalShape2 is not in this collection.")
        Else
            ' Change the index to 0.
            OvalShape1.Parent.Shapes.SetChildIndex(OvalShape2, 0)
        End If
    End Sub
    ' </Snippet1>
End Class
