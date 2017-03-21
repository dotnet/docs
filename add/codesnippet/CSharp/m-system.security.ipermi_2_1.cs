    // Return a new object that matches 'this' object's permissions.
    public sealed override IPermission Copy()
    {
        return (IPermission)Clone();
    }