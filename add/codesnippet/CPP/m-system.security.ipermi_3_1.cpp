    // Return a new object that contains the intersection 
    // of 'this' and 'target'.
public:
    virtual IPermission^ Intersect(IPermission^ target) override
    {
        // If 'target' is null, return null.
        if (target == nullptr)
        {
            return nullptr;
        }

        // Both objects must be the same type.
        SoundPermission^ soundPerm = VerifyTypeMatch(target);

        // If 'this' and 'target' are unrestricted, 
        // return a new unrestricted permission.
        if (specifiedAsUnrestricted && soundPerm->specifiedAsUnrestricted)
        {
            return Clone(true, SoundPermissionState::PlayAnySound);
        }

        // Calculate the intersected permissions. 
        // If there are none, return null.
        SoundPermissionState minimumPermission = (SoundPermissionState)
            Math::Min((int) stateFlags, (int) soundPerm->stateFlags);
        if ((int)minimumPermission == 0)
        {
            return nullptr;
        }

        // Return a new object with the intersected permission value.
        return Clone(false, minimumPermission);
    }