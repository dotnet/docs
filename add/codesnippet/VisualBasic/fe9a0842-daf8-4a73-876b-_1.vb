        Dim permission As New System.Net.NetworkInformation.NetworkInformationPermission( _
            System.Security.Permissions.PermissionState.None)
        permission.AddPermission(System.Net.NetworkInformation.NetworkInformationAccess.Read)
        Console.WriteLine("Access is {0}", permission.Access)