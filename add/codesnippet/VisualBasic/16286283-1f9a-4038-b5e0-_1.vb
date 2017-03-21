      ' Execute the Add method.
        Dim outputCacheProfile0 _
        As New System.Web.Configuration.OutputCacheProfile( _
        "MyCacheProfile")
        outputCacheProfile0.Location = _
        System.Web.UI.OutputCacheLocation.Any
        outputCacheProfile0.NoStore = _
        False
      
        outputCacheProfiles.Add(outputCacheProfile0)
      
      ' Update if not locked.
        If Not outputCacheSettings.IsReadOnly() Then
            webConfig.Save()
        End If