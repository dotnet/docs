        ' Create a base Uri.
        Dim baseUri As New Uri("http://www.contoso.com/")
        
        ' Create a new Uri from a string.
        Dim uriAddress As New Uri("http://www.contoso.com/index.htm?date=today")
        
        ' Determine whether BaseUri is a base of UriAddress.  
        If baseUri.IsBaseOf(uriAddress) Then
            Console.WriteLine("{0} is the base of {1}", baseUri, uriAddress)
        End If