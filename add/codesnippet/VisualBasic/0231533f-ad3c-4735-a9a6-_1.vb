    Private Shared Sub IntersectDemo()
        Dim memberAccessPerm As New ReflectionPermission(ReflectionPermissionFlag.MemberAccess)
        Dim restrictedMemberAccessPerm As New ReflectionPermission(ReflectionPermissionFlag.RestrictedMemberAccess)
        Dim reflectionPerm3 As ReflectionPermission = CType(memberAccessPerm.Intersect(restrictedMemberAccessPerm), ReflectionPermission)
        If Not (reflectionPerm3 Is Nothing) Then
            Console.WriteLine("The intersection of " + memberAccessPerm.Flags.ToString() + _
            " and " + restrictedMemberAccessPerm.Flags.ToString() + " = " + _
            CType(reflectionPerm3, ReflectionPermission).Flags.ToString())
        Else
            Console.WriteLine("The intersection of " + memberAccessPerm.Flags.ToString + " and " + _
                restrictedMemberAccessPerm.Flags.ToString() + " is null.")
        End If

    End Sub 'IntersectDemo

