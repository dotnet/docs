        Dim address6 As New Uri("gopher://example.contoso.com/")
        If address6.Scheme = Uri.UriSchemeGopher Then
            Console.WriteLine("Uri is Gopher protocol")
        End If 