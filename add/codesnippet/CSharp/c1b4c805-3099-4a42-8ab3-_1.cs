
      // Create an instance of 'Regex' that accepts all  URL's containing the host 
      // fragment 'www.contoso.com'.
      Regex myRegex = new Regex(@"http://www\.contoso\.com/.*");

     // Create a WebPermission that gives the permissions to all the hosts containing 
     // the same fragment.
     WebPermission myWebPermission = new WebPermission(NetworkAccess.Connect,myRegex);
        
     // Checks all callers higher in the call stack have been granted the permission.
     myWebPermission.Demand();
      