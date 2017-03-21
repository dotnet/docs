    Private Shared Sub IsSubsetOfDemo()

        Dim memberAccessPerm As New ReflectionPermission(ReflectionPermissionFlag.MemberAccess)
        Dim restrictedMemberAccessPerm As New ReflectionPermission(ReflectionPermissionFlag.RestrictedMemberAccess)
        If restrictedMemberAccessPerm.IsSubsetOf(memberAccessPerm) Then
            Console.WriteLine(restrictedMemberAccessPerm.Flags + " is a subset of " + memberAccessPerm.Flags)
        Else
            Console.WriteLine(restrictedMemberAccessPerm.Flags.ToString() + _
            " is not a subset of " + memberAccessPerm.Flags.ToString())
        End If

    End Sub 'IsSubsetOfDemo
