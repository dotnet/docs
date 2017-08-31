Public Class ShapeCollectionCount
    ' <Snippet1>
    Private Sub Shapes_Click(
      ) Handles RectangleShape1.Click, 
                OvalShape1.Click, LineShape1.Click
        Dim i As Integer = ShapeContainer1.Shapes.Count
        MsgBox("There are " & CStr(i) & " shapes in the collection.")
    End Sub
    ' </Snippet1>
End Class
