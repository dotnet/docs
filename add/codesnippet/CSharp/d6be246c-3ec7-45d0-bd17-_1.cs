            // Open a new PermissionSet.
            PermissionSet ps1 = new PermissionSet(PermissionState.None);
            Console.WriteLine("Adding permission to open a file from a file dialog box.");
            // Add a permission to the permission set.
            ps1.AddPermission(
                new FileDialogPermission(FileDialogPermissionAccess.Open));
            Console.WriteLine("Demanding permission to open a file.");
            ps1.Demand();
            Console.WriteLine("Demand succeeded.");