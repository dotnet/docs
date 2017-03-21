    ' AddPathList adds access for the specified registry variables to the existing state of the permission.
    ' SetPathList sets new access for the specified registry variable names to the existing state of the permission.
    ' GetPathList gets paths for all registry variables with the specified RegistryPermissionAccess.
    Private Shared Function SetGetPathListDemo() As Boolean
        Try
            Console.WriteLine("********************************************************" + vbLf)
            Dim readPerm1 As RegistryPermission
            Console.WriteLine("Creating RegistryPermission with AllAccess rights for 'HKEY_LOCAL_MACHINE\HARDWARE\DESCRIPTION\System\CentralProcessor\0'")
            readPerm1 = New RegistryPermission(RegistryPermissionAccess.AllAccess, "HKEY_LOCAL_MACHINE\HARDWARE\DESCRIPTION\System\CentralProcessor\0")
            Console.WriteLine("Adding 'HKEY_LOCAL_MACHINE\HARDWARE\DESCRIPTION' to the write access list, " + "and " + vbLf + " 'HKEY_LOCAL_MACHINE\HARDWARE\DESCRIPTION\System\FloatingPointProcessor\0' " + "to the read access list.")
            readPerm1.AddPathList(RegistryPermissionAccess.Write, "HKEY_LOCAL_MACHINE\HARDWARE\DESCRIPTION")
            readPerm1.AddPathList(RegistryPermissionAccess.Read, "HKEY_LOCAL_MACHINE\HARDWARE\DESCRIPTION\System\FloatingPointProcessor\0")
            Console.WriteLine("Read access list before SetPathList = " + readPerm1.GetPathList(RegistryPermissionAccess.Read))
            Console.WriteLine("Setting read access rights to " + vbLf + "'HKEY_LOCAL_MACHINE\HARDWARE\DESCRIPTION\System\CentralProcessor\0'")
            readPerm1.SetPathList(RegistryPermissionAccess.Read, "HKEY_LOCAL_MACHINE\HARDWARE\DESCRIPTION\System\CentralProcessor\0")
            Console.WriteLine("Read access list after SetPathList = " + vbLf + readPerm1.GetPathList(RegistryPermissionAccess.Read))
            Console.WriteLine("Write access = " + vbLf + readPerm1.GetPathList(RegistryPermissionAccess.Write))
            Console.WriteLine("Write access Registry variables = " + vbLf + readPerm1.GetPathList(RegistryPermissionAccess.AllAccess))
        Catch e As ArgumentException
            ' RegistryPermissionAccess.AllAccess can not be used as a parameter for GetPathList.
            Console.WriteLine("An ArgumentException occured as a result of using AllAccess. " + _
            "AllAccess cannot be used as a parameter in GetPathList because it represents more than one " + _
            "type of registry variable access : " + vbLf + e.Message)
        End Try

        Return True

    End Function 'SetGetPathListDemo
