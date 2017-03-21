        Dim f2 As New FileIOPermission(FileIOPermissionAccess.Read, "C:\test_r")
        f2.AddPathList(FileIOPermissionAccess.Write Or FileIOPermissionAccess.Read, "C:\example\out.txt")
        Try
            f2.Demand()
        Catch s As SecurityException
            Console.WriteLine(s.Message)
        End Try