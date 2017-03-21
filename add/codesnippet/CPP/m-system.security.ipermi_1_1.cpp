    // Called by the Demand method: returns true 
    // if 'this' is a subset of 'target'.
public:
    virtual bool IsSubsetOf(IPermission^ target) override
    {
        // If 'target' is null and this permission allows nothing, 
        // return true.
        if (target == nullptr)
        {
            return (int)stateFlags == 0;
        }

        // Both objects must be the same type.
        SoundPermission^ soundPerm = VerifyTypeMatch(target);

        // Return true if the permissions of 'this' 
        // is a subset of 'target'.
        return stateFlags <= soundPerm->stateFlags;
    }