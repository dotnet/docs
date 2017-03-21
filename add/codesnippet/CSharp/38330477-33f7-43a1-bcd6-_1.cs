    // Create a WebPermission.
    WebPermission myWebPermission1 = new WebPermission();

    // Allow Connect access to the specified URLs.
    myWebPermission1.AddPermission(NetworkAccess.Connect,new Regex("http://www\\.contoso\\.com/.*", 
      RegexOptions.Compiled | RegexOptions.IgnoreCase | RegexOptions.Singleline));
     
    myWebPermission1.Demand();
