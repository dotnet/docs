      ' Create a WebPermission.
      Dim myWebPermission1 As New WebPermission()
      
      ' Allow Connect access to the specified URLs.
      myWebPermission1.AddPermission(NetworkAccess.Connect, New Regex("http://www\.contoso\.com/.*", RegexOptions.Compiled Or RegexOptions.IgnoreCase Or RegexOptions.Singleline))
      
      myWebPermission1.Demand()
      