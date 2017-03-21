        Dim address2 As New Uri("file://server/filename.ext")
        If address2.Scheme = Uri.UriSchemeFile Then
            Console.WriteLine("Uri is a file")
        End If 