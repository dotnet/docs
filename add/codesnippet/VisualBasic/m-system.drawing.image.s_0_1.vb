    Private Sub Button5_Click(ByVal sender As System.Object, _
        ByVal e As System.EventArgs) Handles Button5.Click
        Try
            If (image1 IsNot Nothing) Then
                image1.Save("c:\myBitmap.bmp")
                Button5.Text = "Saved file."
            End If
        Catch ex As Exception
            MessageBox.Show("There was a problem saving the file." _
            & "Check the file permissions.")
        End Try

    End Sub