            GacIdentityPermission Gac1 = new GacIdentityPermission();
            GacIdentityPermission Gac2 = new GacIdentityPermission(PermissionState.None);
            if (Gac1.Equals(Gac2))
                Console.WriteLine("GacIdentityPermission() equals GacIdentityPermission(PermissionState.None).");