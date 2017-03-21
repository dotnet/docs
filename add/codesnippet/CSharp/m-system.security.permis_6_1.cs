    private static void CopyDemo()
    {
        ReflectionPermission memberAccessPerm = new ReflectionPermission(ReflectionPermissionFlag.MemberAccess);
        ReflectionPermission restrictedMemberAccessPerm = (ReflectionPermission)memberAccessPerm.Copy();
        Console.WriteLine("Result of copy = " + restrictedMemberAccessPerm.ToString());
    }