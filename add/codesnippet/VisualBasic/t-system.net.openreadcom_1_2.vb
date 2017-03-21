        Private Shared Sub OpenReadCallback2(ByVal sender As Object, ByVal e As OpenReadCompletedEventArgs)

            Dim reply As Stream = Nothing
            Dim s As StreamReader = Nothing

            Try

                reply = CType(e.Result, Stream)
                s = New StreamReader(reply)
                Console.WriteLine(s.ReadToEnd())
            Finally

                If Not s Is Nothing Then

                    s.Close()
                End If

                If Not reply Is Nothing Then

                    reply.Close()
                End If
            End Try
        End Sub
