        Private Shared Sub UploadFileCallback2(ByVal sender As Object, ByVal e As System.Net.UploadFileCompletedEventArgs)

            Dim reply As String = System.Text.Encoding.UTF8.GetString(e.Result)
            Console.WriteLine(reply)
        End Sub
