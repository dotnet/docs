            // Create a second permission set and compare it to the first permission set.
            ps2.AddPermission(
                new EnvironmentPermission(EnvironmentPermissionAccess.Read, "USERNAME"));
            ps2.AddPermission(
                new EnvironmentPermission(EnvironmentPermissionAccess.Write, "COMPUTERNAME"));
            IEnumerator list =  ps1.GetEnumerator();
            Console.WriteLine("Permissions in first permission set:");
            while (list.MoveNext())
                Console.WriteLine(list.Current.ToString());
            Console.WriteLine("Second permission IsSubsetOf first permission = " + ps2.IsSubsetOf(ps1));