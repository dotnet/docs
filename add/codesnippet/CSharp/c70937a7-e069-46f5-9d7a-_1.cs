    // Called when the tracked object is disconnected.
    [System.Security.Permissions.SecurityPermissionAttribute(
     System.Security.Permissions.SecurityAction.LinkDemand,
     Flags=System.Security.Permissions.SecurityPermissionFlag.Infrastructure)]
    public void DisconnectedObject(Object obj)
    {
        Console.WriteLine("Tracking: An instance of {0} was disconnected.", 
            obj.ToString());
    }