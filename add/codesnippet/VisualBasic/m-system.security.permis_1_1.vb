            ' Check for an unrestricted permission set.
            Dim ps7 As New PermissionSet(PermissionState.Unrestricted)
            Console.WriteLine("Permission set is unrestricted = " & ps7.IsUnrestricted())