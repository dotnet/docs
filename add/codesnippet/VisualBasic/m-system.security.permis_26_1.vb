            ' Display the union of two permission sets.
            Dim ps5 As PermissionSet = ps3.Union(ps4)
            Console.WriteLine("The union of permission set 3 and permission set 4 = " & ps5.ToString())