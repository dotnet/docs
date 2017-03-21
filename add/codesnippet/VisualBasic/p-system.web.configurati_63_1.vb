        ' Get the current Location.
        Dim locationValue _
        As System.Web.UI.OutputCacheLocation = _
        outputCacheProfile.Location
      
      ' Set the Location property to null.
        outputCacheProfile.Location = _
        System.Web.UI.OutputCacheLocation.Server
      