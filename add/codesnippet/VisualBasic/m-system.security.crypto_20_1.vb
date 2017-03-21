    ' To allow a service to hand out instances of a DataProtector we demand unrestricted DataProtectionPermission 
    ' in the constructor, but Assert the permission when ProviderUnprotect is called..  This is similar to FileStream
    ' where access is checked at time of creation, not time of use.
    <SecuritySafeCritical(), DataProtectionPermission(SecurityAction.Assert, UnprotectData:=True)> _
    Protected Overrides Function ProviderUnprotect(ByVal encryptedData() As Byte) As Byte()

        ProtectedMemory.Unprotect(encryptedData, Scope)
        Return encryptedData

    End Function 'ProviderUnprotect
