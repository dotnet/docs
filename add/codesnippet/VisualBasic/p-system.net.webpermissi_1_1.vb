
   ' Set the WebPermissionAttribute  Connect property.
     <WebPermission(SecurityAction.Deny, Connect := "http://www.contoso.com/Private.htm")>  _
      Public Shared Sub CheckConnectPermission(uriToCheck As String)
      Dim permissionToCheck As New WebPermission()
      permissionToCheck.AddPermission(NetworkAccess.Connect, uriToCheck)
      permissionToCheck.Demand()
   End Sub 'CheckConnectPermission
   
   
   Public Shared Sub demoDenySite()
      'Pass the security check.
      CheckConnectPermission("http://www.contoso.com/Public.htm")
      Console.WriteLine("Public page has passed Connect permission check")
      Try
         'Throw a SecurityException.
         CheckConnectPermission("http://www.contoso.com/Private.htm")
         Console.WriteLine("This line will not be printed")
      Catch e As SecurityException
         Console.WriteLine(("Expected exception" + e.Message))
      End Try
   End Sub 'demoDenySite