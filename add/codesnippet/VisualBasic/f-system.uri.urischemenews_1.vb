        Dim address4 As New Uri("news:123456@contoso.com")
        If address4.Scheme = Uri.UriSchemeNews Then
            Console.WriteLine("Uri is an Internet news group")
        End If 