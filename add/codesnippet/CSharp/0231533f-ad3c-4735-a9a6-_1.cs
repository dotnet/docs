    private static void IntersectDemo()
    {
        ReflectionPermission memberAccessPerm = new ReflectionPermission(ReflectionPermissionFlag.MemberAccess);
        ReflectionPermission restrictedMemberAccessPerm = new ReflectionPermission(ReflectionPermissionFlag.RestrictedMemberAccess);
        ReflectionPermission reflectionPerm3 = (ReflectionPermission)memberAccessPerm.Intersect(restrictedMemberAccessPerm);
        if (reflectionPerm3 != null)
        {
            Console.WriteLine("The intersection of " + memberAccessPerm.Flags +
                " and " + restrictedMemberAccessPerm.Flags + " = " +
                ((ReflectionPermission)reflectionPerm3).Flags.ToString());
        }
        else
        {
            Console.WriteLine("The intersection of " + memberAccessPerm.Flags + " and " +
                restrictedMemberAccessPerm.Flags + " is null.");
        }

    }