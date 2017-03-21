    Private Shared Sub ToFromXmlDemo()
        Dim memberAccessPerm As New ReflectionPermission(ReflectionPermissionFlag.MemberAccess)
        Dim restrictedMemberAccessPerm As New ReflectionPermission(PermissionState.None)
        restrictedMemberAccessPerm.FromXml(memberAccessPerm.ToXml())
        Console.WriteLine("Result of ToFromXml = " + restrictedMemberAccessPerm.ToString())

    End Sub 'ToFromXmlDemo
End Class 'ReflectionPermissionDemo