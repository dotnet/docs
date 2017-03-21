            Dim readPerm1 As RegistryPermission
            Console.WriteLine("Creating RegistryPermission with AllAccess rights for 'HKEY_LOCAL_MACHINE\HARDWARE\DESCRIPTION\System\CentralProcessor\0'")
            readPerm1 = New RegistryPermission(RegistryPermissionAccess.AllAccess, "HKEY_LOCAL_MACHINE\HARDWARE\DESCRIPTION\System\CentralProcessor\0")