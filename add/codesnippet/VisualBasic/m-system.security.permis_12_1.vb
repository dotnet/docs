            ' Create a second permission set and compare it to the first permission set.
            ps2.AddPermission(New EnvironmentPermission(EnvironmentPermissionAccess.Read, "USERNAME"))
            ps2.AddPermission(New EnvironmentPermission(EnvironmentPermissionAccess.Write, "COMPUTERNAME"))
            Console.WriteLine("Permissions in first permission set:")
            Dim list As IEnumerator = ps1.GetEnumerator()
            While list.MoveNext()
                Console.WriteLine(list.Current.ToString())
            End While
            Console.WriteLine("Second permission IsSubsetOf first permission = " & ps2.IsSubsetOf(ps1))