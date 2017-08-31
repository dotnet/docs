Imports Microsoft.VisualBasic.PowerPacks
Public Class ShapeCollectionRemove
    ' <Snippet1>
    Private Sub Form1_Click() Handles Me.Click
        Dim canvas As ShapeContainer
        ' Get the ShapeContainer.
        canvas = OvalShape1.Parent
        ' If OvalShape2 is in the same collection, remove it.
        If canvas.Shapes.Contains(OvalShape2) Then
            canvas.Shapes.Remove(OvalShape2)
        End If
    End Sub
    ' </Snippet1>
    ' <Snippet2>
    Private Sub OvalShape2_Click() Handles OvalShape2.Click
        Dim i As Integer
        ' Find the index for OvalShape1.
        i = OvalShape2.Parent.Shapes.GetChildIndex(OvalShape1, False)
        ' If the shape is not in the collection, display a message.
        If i = -1 Then
            MsgBox("OvalShape1 is not in this collection.")
        Else
            ' Remove the shape.
            OvalShape2.Parent.Shapes.RemoveAt(i)
        End If
    End Sub
    ' </Snippet2>
End Class
