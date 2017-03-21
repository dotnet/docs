            System.Net.NetworkInformation.NetworkInformationPermission read = 
                new System.Net.NetworkInformation.NetworkInformationPermission(
                    System.Net.NetworkInformation.NetworkInformationAccess.Read);
            System.Net.NetworkInformation.NetworkInformationPermission copyPermission =
               (System.Net.NetworkInformation.NetworkInformationPermission) read.Copy();