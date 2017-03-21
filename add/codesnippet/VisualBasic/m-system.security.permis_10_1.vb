            ' Display the intersection of two permission sets.
            Dim ps3 As PermissionSet = ps2.Intersect(ps1)
            Console.WriteLine("The intersection of the first permission set and " & "the second permission set = " & ps3.ToString())