    Private Shared Sub CopyDemo()
        Dim memberAccessPerm As New ReflectionPermission(ReflectionPermissionFlag.MemberAccess)
        Dim restrictedMemberAccessPerm As ReflectionPermission = CType(memberAccessPerm.Copy(), ReflectionPermission)
        Console.WriteLine("Result of copy = " + restrictedMemberAccessPerm.ToString())

    End Sub 'CopyDemo
