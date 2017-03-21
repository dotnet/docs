      ' Create the target permission.
      Dim targetPermission As New WebPermission()
      targetPermission.AddPermission(NetworkAccess.Connect, New Regex("www\.contoso\.com/Public/.*"))
      
      ' Create the permission for a URI matching target.
      Dim connectPermission As New WebPermission()
      connectPermission.AddPermission(NetworkAccess.Connect, "www.contoso.com/Public/default.htm")
      
      'The following statement prints true.
      Console.WriteLine(("Is the second URI a subset of the first one?: " & connectPermission.IsSubsetOf(targetPermission)))
   End Sub 'myIsSubsetExample
