            System.Net.NetworkInformation.NetworkInformationPermission unrestricted = 
                new System.Net.NetworkInformation.NetworkInformationPermission(
                    System.Security.Permissions.PermissionState.Unrestricted);

            Console.WriteLine("Is unrestricted? " + unrestricted.IsUnrestricted());

            System.Net.NetworkInformation.NetworkInformationPermission read = 
                new System.Net.NetworkInformation.NetworkInformationPermission(
                    System.Net.NetworkInformation.NetworkInformationAccess.Read);
            System.Net.NetworkInformation.NetworkInformationPermission copyPermission =
               (System.Net.NetworkInformation.NetworkInformationPermission) read.Copy();
            System.Net.NetworkInformation.NetworkInformationPermission unionPermission =
               (System.Net.NetworkInformation.NetworkInformationPermission) read.Union(unrestricted);
            Console.WriteLine("Is subset?" + read.IsSubsetOf(unionPermission));