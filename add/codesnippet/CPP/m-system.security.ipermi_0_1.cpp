    // Return a new object that contains the union of 'this' and 'target'.
    // Note: You do not have to implement this method. 
    // If you do not, the version
    // in CodeAccessPermission does this:
    //    1. If target is not null, a NotSupportedException is thrown.
    //    2. If target is null, then Copy is called and 
    //       the new object is returned.
public:
    virtual IPermission^ Union(IPermission^ target) override
    {
        // If 'target' is null, then return a copy of 'this'.
        if (target == nullptr)
        {
            return Copy();
        }

        // Both objects must be the same type.
        SoundPermission^ soundPerm = VerifyTypeMatch(target);

        // If 'this' or 'target' are unrestricted, 
        // return a new unrestricted permission.
        if (specifiedAsUnrestricted || soundPerm->specifiedAsUnrestricted)
        {
            return Clone(true, SoundPermissionState::PlayAnySound);
        }

        // Return a new object with the calculated, unioned permission value.
        return Clone(false, (SoundPermissionState)
            Math::Max((int) stateFlags, (int) soundPerm->stateFlags));
    }