        Dim f As New FileIOPermission(PermissionState.None)
        f.AllLocalFiles = FileIOPermissionAccess.Read
        Try
            f.Demand()
        Catch s As SecurityException
            Console.WriteLine(s.Message)
        End Try
