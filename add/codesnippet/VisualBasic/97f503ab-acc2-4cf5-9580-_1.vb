    Private Function SetGetPathListDemo() As Boolean 
        Try
            Console.WriteLine("********************************************************" + vbLf)
            Console.WriteLine("Creating an EnvironmentPermission with AllAccess rights for 'TMP'")
            Dim envPerm1 As New EnvironmentPermission(EnvironmentPermissionAccess.AllAccess, "TMP")
            Console.WriteLine("Adding 'TEMP' to the write access list, and 'windir' to the read access list.")
            envPerm1.AddPathList(EnvironmentPermissionAccess.Write, "TEMP")
            envPerm1.AddPathList(EnvironmentPermissionAccess.Read, "windir")
            Console.WriteLine("Read access list before SetPathList = " + envPerm1.GetPathList(EnvironmentPermissionAccess.Read))
            Console.WriteLine("Setting read access to 'TMP'")
            envPerm1.SetPathList(EnvironmentPermissionAccess.Read, "TMP")
            Console.WriteLine("Read access list after SetPathList = " + envPerm1.GetPathList(EnvironmentPermissionAccess.Read))
            Console.WriteLine("Write access list = " + envPerm1.GetPathList(EnvironmentPermissionAccess.Write))
            Console.WriteLine("Write access environment variables = " + envPerm1.GetPathList(EnvironmentPermissionAccess.AllAccess))
        Catch e As ArgumentException
            ' EnvironmentPermissionAccess.AllAccess cannot be used as a parameter for GetPathList.
            Console.WriteLine("An ArgumentException occurred as a result of using AllAccess. " + _
            " This property cannot be used as a parameter in GetPathList, because it represents " + _
            "more than one type of environment variable : " + vbLf + e.Message)
        End Try
        
        Return True
    
    End Function 'SetGetPathListDemo
    