    private static void UnionDemo()
    {
        ReflectionPermission memberAccessPerm = new ReflectionPermission(ReflectionPermissionFlag.MemberAccess);
        ReflectionPermission restrictedMemberAccessPerm = new ReflectionPermission(ReflectionPermissionFlag.RestrictedMemberAccess);
        ReflectionPermission reflectionPerm3 = (ReflectionPermission)memberAccessPerm.Union(restrictedMemberAccessPerm);
        if (reflectionPerm3 == null)
        {
            Console.WriteLine("The union of " + memberAccessPerm.Flags + " and " +
                restrictedMemberAccessPerm.Flags + " is null.");
        }
        else
        {
            Console.WriteLine("The union of " + memberAccessPerm.Flags + " and " +
                restrictedMemberAccessPerm.Flags + " = " +
                ((ReflectionPermission)reflectionPerm3).Flags.ToString());
        }

    }