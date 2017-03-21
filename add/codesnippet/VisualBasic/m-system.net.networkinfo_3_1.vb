        Dim unrestricted As New System.Net.NetworkInformation.NetworkInformationPermission( _
            System.Security.Permissions.PermissionState.Unrestricted)
        Console.WriteLine("Is unrestricted? " + unrestricted.IsUnrestricted().ToString())