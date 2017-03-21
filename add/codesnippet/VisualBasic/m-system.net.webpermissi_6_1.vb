      ' Create another WebPermission instance that is the copy of the above WebPermission instance.
      Dim myWebPermission2 As WebPermission = CType(myWebPermission1.Copy(), WebPermission)
      
      ' Check whether all callers higher in the call stack have been granted the permissionor not.
      myWebPermission2.Demand()
      