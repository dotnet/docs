    // Returns true if permission is effectively unrestricted.
public:
    virtual bool IsUnrestricted()
    {
        // This means that the object is unrestricted at runtime.
        return stateFlags == SoundPermissionState::PlayAnySound;
    }