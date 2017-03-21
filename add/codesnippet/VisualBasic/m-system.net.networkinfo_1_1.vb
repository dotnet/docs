        Dim read As New System.Net.NetworkInformation.NetworkInformationPermission( _ 
            System.Net.NetworkInformation.NetworkInformationAccess.Read)
        Dim copyPermission As System.Net.NetworkInformation.NetworkInformationPermission = _
            CType(read.Copy(), System.Net.NetworkInformation.NetworkInformationPermission)