      [System.Security.Permissions.PermissionSet(System.Security.Permissions.SecurityAction.Demand, Name="FullTrust")] 
      protected override ControlCollection CreateControlCollection()
      {
         myControlCollection=new ControlCollection(this);
         return myControlCollection;
      }