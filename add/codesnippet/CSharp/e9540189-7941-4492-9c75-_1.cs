    // Called when the tracked object is unmarshaled.
    [System.Security.Permissions.SecurityPermissionAttribute(
     System.Security.Permissions.SecurityAction.LinkDemand,
     Flags=System.Security.Permissions.SecurityPermissionFlag.Infrastructure)]
    public void UnmarshaledObject(Object obj, ObjRef objRef)
    {
        Console.WriteLine("Tracking: An instance of {0} was unmarshaled.", 
            obj.ToString());
    }