        Dim unrestricted As New System.Net.NetworkInformation.NetworkInformationPermission( _
            System.Security.Permissions.PermissionState.Unrestricted)
        Console.WriteLine("Is unrestricted? " + unrestricted.IsUnrestricted().ToString())
        Dim read As New System.Net.NetworkInformation.NetworkInformationPermission( _ 
            System.Net.NetworkInformation.NetworkInformationAccess.Read)
        Dim copyPermission As System.Net.NetworkInformation.NetworkInformationPermission = _
            CType(read.Copy(), System.Net.NetworkInformation.NetworkInformationPermission)
        Dim unionPermission As System.Net.NetworkInformation.NetworkInformationPermission = _
            CType(read.Union(unrestricted), System.Net.NetworkInformation.NetworkInformationPermission)
        Console.WriteLine("Is subset?" + read.IsSubsetOf(unionPermission).ToString())
        Dim intersectPermission As System.Net.NetworkInformation.NetworkInformationPermission = _ 
            CType(read.Intersect(unrestricted), _ 
                  System.Net.NetworkInformation.NetworkInformationPermission)