    // Return a new object that matches 'this' object's permissions.
public:
    virtual IPermission^ Copy () override sealed
    {
        return (IPermission^) Clone();
    }