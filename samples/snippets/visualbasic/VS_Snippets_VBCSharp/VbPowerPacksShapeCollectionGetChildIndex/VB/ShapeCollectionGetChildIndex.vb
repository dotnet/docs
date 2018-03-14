Public Class ShapeCollectionGetChildIndex
    ' <Snippet1>
    Private Sub OvalShape2_Click() Handles OvalShape2.Click
        Dim i As Integer
        ' Find the index for OvalShape1.
        i = OvalShape2.Parent.Shapes.GetChildIndex(OvalShape1)
        MsgBox("The index for OvalShape1 is " & CStr(i))
    End Sub
    ' </Snippet1>
    ' <Snippet2>
    Private Sub OvalShape1_Click() Handles OvalShape1.Click
        Dim i As Integer
        ' Find the index for OvalShape1.
        i = OvalShape1.Parent.Shapes.GetChildIndex(OvalShape2, False)
        ' If the shape is not in the collection, display a message.
        If i = -1 Then
            MsgBox("OvalShape2 is not in this collection.")
        Else
            MsgBox("The index for OvalShape2 is " & CStr(i))
        End If
    End Sub
    ' </Snippet2>
End Class
