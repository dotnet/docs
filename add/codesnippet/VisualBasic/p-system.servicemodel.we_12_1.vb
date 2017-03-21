        Dim current As WebOperationContext = WebOperationContext.Current
        Console.WriteLine("Incoming Response")
        Console.WriteLine("ContentLength: " + current.IncomingResponse.ContentLength)
        Console.WriteLine("ContentType: " + current.IncomingResponse.ContentType)
        Console.WriteLine("StatusCode: " + current.IncomingResponse.StatusCode)