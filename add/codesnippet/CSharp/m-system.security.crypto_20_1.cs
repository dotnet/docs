        // To allow a service to hand out instances of a DataProtector we demand unrestricted DataProtectionPermission 
        // in the constructor, but Assert the permission when ProviderUnprotect is called..  This is similar to FileStream
        // where access is checked at time of creation, not time of use.
        [SecuritySafeCritical]
        [DataProtectionPermission(SecurityAction.Assert, UnprotectData = true)]
        protected override byte[] ProviderUnprotect(byte[] encryptedData)
        {

            ProtectedMemory.Unprotect(encryptedData,Scope);           
                return encryptedData;
        }