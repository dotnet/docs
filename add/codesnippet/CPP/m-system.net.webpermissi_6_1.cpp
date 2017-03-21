      // Create another WebPermission instance that is the copy of the above WebPermission instance.
      WebPermission^ myWebPermission2 = (WebPermission^)(myWebPermission1->Copy());
      
      // Check whether all callers higher in the call stack have been granted the permissionor not.
      myWebPermission2->Demand();