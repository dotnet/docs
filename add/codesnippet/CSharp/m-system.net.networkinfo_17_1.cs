            System.Net.NetworkInformation.NetworkInformationPermission unrestricted = 
                new System.Net.NetworkInformation.NetworkInformationPermission(
                    System.Security.Permissions.PermissionState.Unrestricted);

            Console.WriteLine("Is unrestricted? " + unrestricted.IsUnrestricted());