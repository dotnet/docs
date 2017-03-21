            ' Change the permission set using SetPermission.
            ps5.SetPermission(New EnvironmentPermission(EnvironmentPermissionAccess.AllAccess, "USERNAME"))
            Console.WriteLine("Permission set after SetPermission = " & ps5.ToString())