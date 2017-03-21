    // Called by the Demand method: returns true if 'this' is a subset of 'target'.
    public override Boolean IsSubsetOf(IPermission target)
    {
        // If 'target' is null and this permission allows nothing, return true.
        if (target == null) return m_flags == 0;

        // Both objects must be the same type.
        SoundPermission soundPerm = VerifyTypeMatch(target);

        // Return true if the permissions of 'this' is a subset of 'target'.
        return m_flags <= soundPerm.m_flags;
    }