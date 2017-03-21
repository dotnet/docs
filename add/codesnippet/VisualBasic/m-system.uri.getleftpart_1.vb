        ' Create Uri
        Dim uriAddress As New Uri("http://www.contoso.com/index.htm#search")
        Console.WriteLine(uriAddress.Fragment)
        Console.WriteLine("Uri {0} the default port ", IIf(uriAddress.IsDefaultPort, "uses", "does not use")) 'TODO: For performance reasons this should be changed to nested IF statements
        
        Console.WriteLine("The path of this Uri is {0}", uriAddress.GetLeftPart(UriPartial.Path))
        Console.WriteLine("Hash code {0}", uriAddress.GetHashCode())