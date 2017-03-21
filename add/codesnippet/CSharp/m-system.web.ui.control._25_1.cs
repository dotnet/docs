   // Override the OnInit method to set _text to
   // a default value if it is null.
   [System.Security.Permissions.PermissionSet
       (System.Security.Permissions.SecurityAction.Demand, 
        Name="FullTrust")] 
   protected override void OnInit(EventArgs e)
   {
      base.OnInit(e);
      if ( _text == null)
           _text = "Here is some default text.";
   }