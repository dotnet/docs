        For i As Integer = 0 To 2
            Try
                Dim large As LargeObject = lazyLargeObject.Value
                large.Data(11) = 89
            Catch aex As ApplicationException
                Console.WriteLine("Exception: {0}", aex.Message)
            End Try
        Next i