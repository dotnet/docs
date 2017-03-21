  '  Creates an instance of 'Regex' that accepts all  URL's containing the host fragment 'www.contoso.com'.
  Dim myRegex As New Regex("http://www\.contoso\.com/.*")
    
     ' Creates a 'WebPermission' that gives the permissions to all the hosts containing same host fragment.
     Dim myWebPermission As New WebPermission(NetworkAccess.Connect, myRegex)
     
    '  Checks all callers higher in the call stack have been granted the permission.
    myWebPermission.Demand()
