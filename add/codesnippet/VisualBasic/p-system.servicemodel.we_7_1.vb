        WebOperationContext.Current.OutgoingRequest.Headers.Add("Slug", "title")
        WebOperationContext.Current.OutgoingRequest.Method = "GET"
        WebOperationContext.Current.OutgoingRequest.ContentType = "application/octet-stream"