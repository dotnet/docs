        Dim current As WebOperationContext = WebOperationContext.Current
        Dim headers As WebHeaderCollection = current.IncomingRequest.Headers

        For Each name As String In headers
            Console.WriteLine(name + " " + headers.Get(name))
        Next