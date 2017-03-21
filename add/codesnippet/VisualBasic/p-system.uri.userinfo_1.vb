        Dim uriAddress As New Uri("http://user:password@www.contoso.com/index.htm ")
        Console.WriteLine(uriAddress.UserInfo)
        Console.WriteLine("Fully Escaped {0}", IIf(uriAddress.UserEscaped, "yes", "no")) 'TODO: For performance reasons this should be changed to nested IF statements
    
    End Sub 'SampleUserInfo 