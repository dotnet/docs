            // Change the permission set using SetPermission.
            ps5.SetPermission(new EnvironmentPermission(EnvironmentPermissionAccess.AllAccess, "USERNAME"));
            Console.WriteLine("Permission set after SetPermission = " + ps5.ToString());