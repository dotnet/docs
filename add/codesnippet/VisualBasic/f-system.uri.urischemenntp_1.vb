        Dim address5 As New Uri("nntp://news.contoso.com/123456@contoso.com")
        If address5.Scheme = Uri.UriSchemeNntp Then
            Console.WriteLine("Uri is nntp protocol")
        End If 