        Private Shared Sub UploadFileCallback(ByVal sender As Object, ByVal e As System.Net.UploadFileCompletedEventArgs)

            Dim waiter As System.Threading.AutoResetEvent = CType(e.UserState, System.Threading.AutoResetEvent)
            Try

                Dim reply As String = System.Text.Encoding.UTF8.GetString(e.Result)
                Console.WriteLine(reply)
            Finally
                '  If this thread throws an exception, make sure that
                '  you let the main application thread resume.
                waiter.Set()
            End Try
        End Sub
