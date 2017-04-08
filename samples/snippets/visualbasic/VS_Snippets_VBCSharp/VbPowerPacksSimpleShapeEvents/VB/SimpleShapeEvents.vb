Imports Microsoft.VisualBasic.PowerPacks

Public Class SimpleShapeEvents

    ' <Snippet1>
    Private Sub RectangleShape1_BackColorChanged(
      ) Handles RectangleShape1.BackColorChanged

        ' The BackStyle must be Opaque or the BackColor has no effect.
        If RectangleShape1.BackStyle = BackStyle.Transparent Then
            RectangleShape1.BackStyle = BackStyle.Opaque
        End If
    End Sub
    ' </Snippet1>

    ' <Snippet2>
    Private Sub RectangleShape1_BackgroundImageChanged(
      ) Handles RectangleShape1.BackgroundImageChanged

        ' Display a message in the Label.
        Label1.Text = "The picture has changed."
    End Sub
    ' </Snippet2>

    ' <Snippet3>
    Private Sub RectangleShape1_BackgroundImageLayoutChanged(
      ) Handles RectangleShape1.BackgroundImageLayoutChanged

        ' If the image is centered, check its size.
        If RectangleShape1.BackgroundImageLayout = ImageLayout.Center Then
            Dim imageSize As SizeF
            imageSize = RectangleShape1.BackgroundImage.PhysicalDimension
            ' If the image is smaller than the shape, change the BackColor.
            If imageSize.Height < RectangleShape1.ClientSize.Height OrElse
              imageSize.Width < RectangleShape1.ClientSize.Width Then
                RectangleShape1.BackColor = Color.Black
            End If
        End If
    End Sub
    ' </Snippet3>

    ' <Snippet4>
    Private Sub RectangleShape1_ClientSizeChanged(
      ) Handles RectangleShape1.ClientSizeChanged

        ' Restrict the shape to a certain width range.
        If RectangleShape1.Width > 300 Then
            RectangleShape1.Width = 300
        ElseIf RectangleShape1.Width < 50 Then
            RectangleShape1.Width = 50
        End If
    End Sub
    ' </Snippet4>

    ' <Snippet5>
    Private Sub RectangleShape1_LocationChanged(
      ) Handles RectangleShape1.LocationChanged

        ' If the second rectangle intersects with the first, move it.
        If RectangleShape1.ClientRectangle.IntersectsWith( 
          RectangleShape2.ClientRectangle) Then
            RectangleShape2.Location = New Point(RectangleShape1.Right, 
             RectangleShape1.Bottom)
        End If
    End Sub
    ' </Snippet5>

    ' <Snippet6>
    Private Sub RectangleShape1_Resize() Handles RectangleShape1.Resize
        ' If the second rectangle intersects with the first, move it.
        If RectangleShape1.ClientRectangle.IntersectsWith( 
          RectangleShape2.ClientRectangle) Then
            RectangleShape2.Location = New Point(RectangleShape1.Right, 
              RectangleShape1.Bottom)
        End If
    End Sub
    ' </Snippet6>

    ' <Snippet7>
    Private Sub RectangleShape1_SizeChanged() Handles RectangleShape1.SizeChanged
        ' If the second rectangle intersects with the first, move it.
        If RectangleShape1.ClientRectangle.IntersectsWith( 
          RectangleShape2.ClientRectangle) Then
            RectangleShape2.Location = New Point(RectangleShape1.Right, 
              RectangleShape1.Bottom)
        End If
    End Sub
    ' </Snippet7>
End Class
