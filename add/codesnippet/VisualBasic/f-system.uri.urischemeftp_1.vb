        Dim address7 As New Uri("ftp://contoso/files/testfile.txt")
        If address7.Scheme = Uri.UriSchemeFtp Then
            Console.WriteLine("Uri is Ftp protocol")
        End If 