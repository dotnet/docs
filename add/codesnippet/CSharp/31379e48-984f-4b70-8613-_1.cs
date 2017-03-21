    private static void ToFromXmlDemo()
    {
        ReflectionPermission memberAccessPerm = new ReflectionPermission(ReflectionPermissionFlag.MemberAccess);
        ReflectionPermission restrictedMemberAccessPerm = new ReflectionPermission(PermissionState.None);
        restrictedMemberAccessPerm.FromXml(memberAccessPerm.ToXml());
        Console.WriteLine("Result of ToFromXml = " +
            restrictedMemberAccessPerm.ToString());
    }