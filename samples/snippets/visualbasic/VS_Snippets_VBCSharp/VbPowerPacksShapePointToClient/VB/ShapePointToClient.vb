Public Class ShapePointToClient
    ' <Snippet1>
    Private Sub Form1_DragDrop(
        ByVal sender As Object, 
        ByVal e As System.Windows.Forms.DragEventArgs
      ) Handles Me.DragDrop

        ' Determine whether the drop is within the rectangle.
        If RectangleShape1.HitTest(e.X, e.Y) = True Then
            ' Handle file data.
            If e.Data.GetDataPresent(DataFormats.FileDrop) Then
                ' Assign the file names to a string array, in 
                ' case the user has selected multiple files.
                Dim files As String() = 
                  CType(e.Data.GetData(DataFormats.FileDrop), String())
                Try
                    ' Assign the first image to the BackGroundImage
                    ' property.
                    RectangleShape1.BackgroundImage = 
                      Image.FromFile(files(0))
                    ' Set the rectangle location relative to the form.
                    RectangleShape1.Location = 
                      RectangleShape1.PointToClient(New Point(e.X, e.Y))
                Catch ex As Exception
                    MessageBox.Show(ex.Message)
                    Return
                End Try
            End If
        End If
    End Sub
    Private Sub Form1_DragEnter(
        ByVal sender As Object, 
        ByVal e As DragEventArgs
      ) Handles MyBase.DragEnter

        ' If the data is a file, display the copy cursor.
        If e.Data.GetDataPresent(DataFormats.FileDrop) Then
            e.Effect = DragDropEffects.Copy
        Else
            e.Effect = DragDropEffects.None
        End If
    End Sub
    ' </Snippet1>
End Class
