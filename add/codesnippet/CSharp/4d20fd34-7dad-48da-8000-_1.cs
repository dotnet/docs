    private static void IsSubsetOfDemo()
    {
        ReflectionPermission memberAccessPerm = new ReflectionPermission(ReflectionPermissionFlag.MemberAccess);
        ReflectionPermission restrictedMemberAccessPerm = new ReflectionPermission(ReflectionPermissionFlag.RestrictedMemberAccess);

        if (restrictedMemberAccessPerm.IsSubsetOf(memberAccessPerm))
        {
            Console.WriteLine(restrictedMemberAccessPerm.Flags + " is a subset of " +
                memberAccessPerm.Flags);
        }
        else
        {
            Console.WriteLine(restrictedMemberAccessPerm.Flags + " is not a subset of " +
                memberAccessPerm.Flags);
        }
    }