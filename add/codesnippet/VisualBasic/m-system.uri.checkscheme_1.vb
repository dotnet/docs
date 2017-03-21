        Dim address1 As New Uri("http://www.contoso.com/index.htm#search")
        Console.WriteLine("address 1 {0} a valid scheme name", IIf(Uri.CheckSchemeName(address1.Scheme), " has", " does not have")) 'TODO: For performance reasons this should be changed to nested IF statements
        
        If address1.Scheme = Uri.UriSchemeHttp Then
            Console.WriteLine("Uri is HTTP type")
        End If 
        Console.WriteLine(address1.HostNameType)