      ' Create a WebPermission instance.  
      Dim myWebPermission1 As New WebPermission(PermissionState.None)
      
      ' Allow access to the first set of URL's.
      myWebPermission1.AddPermission(NetworkAccess.Connect, "http://www.microsoft.com/default.htm")
      myWebPermission1.AddPermission(NetworkAccess.Connect, "http://www.msn.com")
      
      ' Check whether all callers higher in the call stack have been granted the permissionor not.
      myWebPermission1.Demand()
      