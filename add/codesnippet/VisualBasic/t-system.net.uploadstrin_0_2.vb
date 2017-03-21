        Private Shared Sub UploadStringCallback2(ByVal sender As Object, ByVal e As UploadStringCompletedEventArgs)
            Dim reply As String = CStr(e.Result)
            Console.WriteLine(reply)
        End Sub