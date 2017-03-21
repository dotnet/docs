    // Returns true if permission is effectively unrestricted.
    public Boolean IsUnrestricted()
    {
        // This means that the object is unrestricted at runtime.
        return m_flags == SoundPermissionState.PlayAnySound;
    }