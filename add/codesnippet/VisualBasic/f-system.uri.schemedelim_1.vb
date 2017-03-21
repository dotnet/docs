        Dim address As String = "www.contoso.com"
        Dim uriString As String = String.Format("{0}{1}{2}", Uri.UriSchemeHttp, Uri.SchemeDelimiter, address)
        
        Dim result As Uri = New Uri(uriString)

        If result.IsWellFormedOriginalString() = True Then
            Console.WriteLine("{0} is a well formed Uri", uriString)
        else
            Console.WriteLine("{0} is not a well formed Uri", uriString)
        End If