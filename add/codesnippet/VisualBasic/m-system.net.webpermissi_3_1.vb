      ' Create a WebPermission.instance.
      Dim myWebPermission1 As New WebPermission(NetworkAccess.Connect, "http://www.contoso.com/default.htm")
      myWebPermission1.Demand()
      