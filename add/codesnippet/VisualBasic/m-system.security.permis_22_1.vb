            ' Remove FileIOPermission from the permission set.
            ps5.RemovePermission(GetType(FileIOPermission))
            Console.WriteLine("The last permission set after removing FileIOPermission = " & ps5.ToString())