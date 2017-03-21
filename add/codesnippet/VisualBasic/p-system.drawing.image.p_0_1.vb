    Private Sub ExtractMetaData(ByVal e As PaintEventArgs)

        Try
            'Create an Image object. 
            Dim theImage As Image = New Bitmap("c:\fakePhoto.jpg")

            'Get the PropertyItems property from image.
            Dim propItems As PropertyItem() = theImage.PropertyItems

            'Set up the display.
            Dim font As New font("Arial", 10)
            Dim blackBrush As New SolidBrush(Color.Black)
            Dim X As Integer = 0
            Dim Y As Integer = 0

            'For each PropertyItem in the array, display the id, type, and length.
            Dim count As Integer = 0
            Dim propItem As PropertyItem
            For Each propItem In propItems

                e.Graphics.DrawString("Property Item " + count.ToString(), _
                   font, blackBrush, X, Y)
                Y += font.Height

                e.Graphics.DrawString("   iD: 0x" & propItem.Id.ToString("x"), _
                   font, blackBrush, X, Y)
                Y += font.Height

                e.Graphics.DrawString("   type: " & propItem.Type.ToString(), _
                   font, blackBrush, X, Y)
                Y += font.Height

                e.Graphics.DrawString("   length: " & propItem.Len.ToString() & _
                    " bytes", font, blackBrush, X, Y)
                Y += font.Height

                count += 1
            Next propItem

            font.Dispose()
        Catch ex As ArgumentException
            MessageBox.Show("There was an error. Make sure the path to the image file is valid.")
        End Try

    End Sub