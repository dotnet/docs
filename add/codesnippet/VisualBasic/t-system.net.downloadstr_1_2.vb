        Private Shared Sub DownloadStringCallback2(ByVal sender As Object, ByVal e As DownloadStringCompletedEventArgs)

            '  If the request was not canceled and did not throw
            '  an exception, display the resource.
            If e.Cancelled = False AndAlso e.Error Is Nothing Then

                Dim textString As String = CStr(e.Result)
                Console.WriteLine(textString)
            End If
        End Sub
