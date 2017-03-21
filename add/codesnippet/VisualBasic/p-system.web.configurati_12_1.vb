      ' Get the current Protection.
        Dim currentProtection As FormsProtectionEnum = _
        formsAuthentication.Protection
      
      ' Set the Protection property.
      formsAuthentication.Protection = FormsProtectionEnum.All
      