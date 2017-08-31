Imports Microsoft.VisualBasic.PowerPacks

Public Class ShapeContainerGetChild
    ' <Snippet1>
    Private Sub ShapeContainer1_MouseDown(
        ByVal sender As Object, 
        ByVal e As System.Windows.Forms.MouseEventArgs
      ) Handles ShapeContainer1.MouseDown

        Dim sh As Shape
        ' Find the shape at the point where the mouse was clicked.
        sh = ShapeContainer1.GetChildAtPoint(New Point(e.X, e.Y))
        MsgBox(sh.Name)
    End Sub
    ' </Snippet1>
End Class
