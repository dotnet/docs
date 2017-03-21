
    // Create a WebPermission.instance.
    WebPermission myWebPermission1 = new WebPermission(NetworkAccess.Connect,"http://www.contoso.com/default.htm");
    myWebPermission1.Demand();
