        Dim ppBob As New PrincipalPermission("Bob", "Administrator")
        Dim ppLouise As New PrincipalPermission("Louise", "Administrator")
        Dim pp1 As IPermission = ppBob.Intersect(ppLouise)