        ' Get the role using the WellKnownSidType.
        Dim sid As New SecurityIdentifier(WellKnownSidType.BuiltinAdministratorsSid, Nothing)
        Console.WriteLine("WellKnownSidType BuiltinAdministratorsSid  {0}? {1}.", sid.Value, myPrincipal.IsInRole(sid))

    End Sub 'DemonstrateWindowsBuiltInRoleEnum