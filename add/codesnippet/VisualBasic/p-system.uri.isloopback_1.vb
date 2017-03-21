        Dim uriAddress2 As New Uri("file://server/filename.ext")
        Console.WriteLine(uriAddress2.LocalPath)
        Console.WriteLine("Uri {0} a UNC path", IIf(uriAddress2.IsUnc, "is", "is not")) 'TODO: For performance reasons this should be changed to nested IF statements
        Console.WriteLine("Uri {0} a local host", IIf(uriAddress2.IsLoopback, "is", "is not")) 'TODO: For performance reasons this should be changed to nested IF statements
        Console.WriteLine("Uri {0} a file", IIf(uriAddress2.IsFile, "is", "is not")) 'TODO: For performance reasons this should be changed to nested IF statements
    
    End Sub 'GetParts