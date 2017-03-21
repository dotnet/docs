 'Define users and roles.
 Dim ppBob As New PrincipalPermission("Bob", "Manager")
 Dim ppLouise As New PrincipalPermission("Louise", "Supervisor")
 Dim ppGreg As New PrincipalPermission("Greg", "Employee")
        
 'Define groups of users.
 Dim pp1 As PrincipalPermission = _
    CType(ppBob.Union(ppLouise), PrincipalPermission)
 Dim pp2 As PrincipalPermission = _
    CType(ppGreg.Union(pp1), PrincipalPermission)