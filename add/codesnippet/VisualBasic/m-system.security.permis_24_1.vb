            Dim Gac1 As New GacIdentityPermission
            Dim Gac2 As New GacIdentityPermission(PermissionState.None)
            If (Gac1.Equals(Gac2)) Then
                Console.WriteLine("GacIdentityPermission() equals GacIdentityPermission(PermissionState.None).")
            End If