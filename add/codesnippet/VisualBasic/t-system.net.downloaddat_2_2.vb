        Private Shared Sub DownloadDataCallback(ByVal sender As Object, ByVal e As DownloadDataCompletedEventArgs)

            Dim waiter As System.Threading.AutoResetEvent = CType(e.UserState, System.Threading.AutoResetEvent)

            Try

                '  If the request was not canceled and did not throw
                '  an exception, display the resource.
                If e.Cancelled = False AndAlso e.Error Is Nothing Then

                    Dim data() As Byte = CType(e.Result, Byte())
                    Dim textData As String = System.Text.Encoding.UTF8.GetString(data)

                    Console.WriteLine(textData)
                End If
            Finally

                '  Let the main application thread resume.
                waiter.Set()
            End Try
        End Sub
