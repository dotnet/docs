    Private Sub InitializeStreamBitmap()
        Try
            Dim request As System.Net.WebRequest = _
                System.Net.WebRequest.Create( _
                "http://www.microsoft.com//h/en-us/r/ms_masthead_ltr.gif")
            Dim response As System.Net.WebResponse = request.GetResponse()
            Dim responseStream As System.IO.Stream = response.GetResponseStream()
            Dim bitmap2 As New Bitmap(responseStream)
            PictureBox1.Image = bitmap2

        Catch ex As System.Net.WebException
            MessageBox.Show("There was an error opening the image file. Check the URL")
        End Try
    End Sub