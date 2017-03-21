        Private Shared Sub OpenWriteCallback2(ByVal sender As Object, ByVal e As OpenWriteCompletedEventArgs)

            Dim body As Stream = Nothing
            Dim s As StreamWriter = Nothing

            Try

                body = CType(e.Result, Stream)
                s = New StreamWriter(body)
                s.AutoFlush = True
                s.Write("This is content data to be sent to the server.")
            Finally

                If Not s Is Nothing Then

                    s.Close()
                End If

                If Not body Is Nothing Then

                    body.Close()
                End If
            End Try
        End Sub
