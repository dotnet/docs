        Dim f3 As New FileIOPermission(PermissionState.None)
        f3.AllFiles = FileIOPermissionAccess.Read
        Try
            f3.Demand()
        Catch s As SecurityException
            Console.WriteLine(s.Message)
        End Try