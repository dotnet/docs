        Private Shared Sub UploadDataCallback2(ByVal sender As Object, ByVal e As UploadDataCompletedEventArgs)

            Dim data() As Byte = CType(e.Result, Byte())
            Dim reply As String = System.Text.Encoding.UTF8.GetString(data)

            Console.WriteLine(reply)
        End Sub
