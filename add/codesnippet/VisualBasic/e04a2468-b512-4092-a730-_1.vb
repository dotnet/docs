    Private Shared Sub UnionDemo()
        Dim memberAccessPerm As New ReflectionPermission(ReflectionPermissionFlag.MemberAccess)
        Dim restrictedMemberAccessPerm As New ReflectionPermission(ReflectionPermissionFlag.RestrictedMemberAccess)
        Dim reflectionPerm3 As ReflectionPermission = _
                CType(memberAccessPerm.Union(restrictedMemberAccessPerm), ReflectionPermission)
        If reflectionPerm3 Is Nothing Then
            Console.WriteLine("The union of " + memberAccessPerm.Flags.ToString() + " and " + _
            restrictedMemberAccessPerm.Flags.ToString() + " is null.")
        Else
            Console.WriteLine("The union of " + memberAccessPerm.Flags.ToString() + _
            " and " + restrictedMemberAccessPerm.Flags.ToString() + " = " + _
            CType(reflectionPerm3, ReflectionPermission).Flags.ToString())
        End If

    End Sub 'UnionDemo

