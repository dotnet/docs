    // Return a new object that contains the intersection of 'this' and 'target'.
    public override IPermission Intersect(IPermission target)
    {
        // If 'target' is null, return null.
        if (target == null) return null;

        // Both objects must be the same type.
        SoundPermission soundPerm = VerifyTypeMatch(target);

        // If 'this' and 'target' are unrestricted, return a new unrestricted permission.
        if (m_specifiedAsUnrestricted && soundPerm.m_specifiedAsUnrestricted)
            return Clone(true, SoundPermissionState.PlayAnySound);

        // Calculate the intersected permissions. If there are none, return null.
        SoundPermissionState val = (SoundPermissionState)
            Math.Min((Int32)m_flags, (Int32)soundPerm.m_flags);
        if (val == 0) return null;

        // Return a new object with the intersected permission value.
        return Clone(false, val);
    }