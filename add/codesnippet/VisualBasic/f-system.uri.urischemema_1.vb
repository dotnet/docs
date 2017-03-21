        Dim address3 As New Uri("mailto:user@contoso.com?subject=uri")
        If address3.Scheme = Uri.UriSchemeMailto Then
            Console.WriteLine("Uri is an email address")
        End If 