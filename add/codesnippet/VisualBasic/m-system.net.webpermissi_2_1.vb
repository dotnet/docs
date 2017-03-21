      ' Allow access to the first set of resources.
      myWebPermission1.AddPermission(NetworkAccess.Connect, "http://www.contoso.com/default.htm")
      myWebPermission1.AddPermission(NetworkAccess.Connect, "http://www.adventure-works.com/default.htm")
      
      ' Check whether if the callers higher in the call stack have been granted 
      ' access permissions.
      myWebPermission1.Demand()
      